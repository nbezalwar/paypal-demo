Imports System.Windows.Controls
Imports BluePrism.AutomateAppCore
Imports LiveCharts
Imports LiveCharts.Wpf

Namespace Controls.Charts
    Partial Public Class BasicColumnChart
        Inherits UserControl
        Implements IBaseChart, IBaseGraph

        Public Sub New(size As Size, tile As Tile,
                       procedure As String, parameters As Dictionary(Of String, String))
            InitializeComponent()
            DataContext = Me
            CreateChartData(procedure, parameters, tile)
            SetTileSize(size)

            Height = 350 * size.Height
            Width = 555 * size.Width
        End Sub

        Public Property LabelPoint As Func(Of ChartPoint, String) = Function(chartPoint)
                                                                        Dim chart = CType(chartPoint.ChartView, Wpf.Charts.Base.Chart)
                                                                        Return $"{chartPoint.Y} - {chart.AxisX(0).Labels(CInt(chartPoint.X))}"
                                                                    End Function

        Private Sub SetTileSize(s As Size) Implements IBaseChart.SetTileSize
            TileSize = SharedMethods.SetTileSize(s)
        End Sub

        Public Property TileSize As _
            TileSize Implements IBaseChart.TileSize
        Public Property Labels As _
            New List(Of String) Implements IBaseGraph.Labels
        Public Property Formatter As _
            Func(Of Double, String) Implements IBaseGraph.Formatter
        Public Property XAxis As _
            String Implements IBaseGraph.XAxis
        Public Property YAxis As _
            String Implements IBaseGraph.YAxis
        Public Property ChartTitle As _
            String Implements IBaseChart.ChartTitle
        Public Property ChartSubTitle As _
            String Implements IBaseChart.ChartSubTitle
        Public Property SeriesCollection As _
            New SeriesCollection Implements IBaseChart.SeriesCollection
        Public Property SharedMethods As _
            New SharedFunctions Implements IBaseChart.SharedMethods
        Public ReadOnly Property HasChartData As Boolean Implements IBaseChart.HasChartData
            Get
                Return SharedMethods.HasDataToDisplay(SeriesCollection)
            End Get
        End Property

        Private Sub CreateChartData(procedure As String, parameters As Dictionary(Of String, String),
                                    tile As Tile) Implements IBaseChart.CreateChartData
            If tile Is Nothing Then
                Throw New ArgumentNullException(NameOf(tile))
            End If

            Dim chartData As DataTable
            'the serises collection can't be null, however empty is fine.
            SeriesCollection = New SeriesCollection
            ChartTitle = tile.Name
            ChartSubTitle = tile.Description

            Try
                chartData = gSv.GetChartData(procedure, parameters)

                If chartData is Nothing Then Throw new ChartNoDataException()

                Dim seriesValues As New List(Of EnumerableRowCollection(Of DataRow))
                For i As Integer = 1 To chartData.Columns.Count - 1
                    seriesValues.Add(New DataView(chartData).ToTable(False, chartData.Columns(i).ColumnName).AsEnumerable)
                Next

                Dim chartSeriesType = SharedMethods.SetSeriesTypeValues(YAxis, XAxis, chartData.Columns, seriesValues)
                Dim count = chartSeriesType.StartIndex
                For Each seriesValue As EnumerableRowCollection In chartSeriesType.SeriesType
                    Dim dataValue As Double
                    Dim values As New List(Of Double)
                    For Each dataRow As DataRow In seriesValue
                        If Double.TryParse(dataRow.Item(0).ToString, dataValue) <> False Then
                            values.Add(dataValue)
                        Else
                            values.Add(0R)
                        End If
                    Next

                    SeriesCollection.Add(
                        New ColumnSeries With {
                            .Values = New ChartValues(Of Double)(values.AsEnumerable),
                            .LabelPoint = LabelPoint,
                            .Title = chartData.Columns(count).ColumnName
                            })
                    count += 1
                Next

                Dim dataLabels As New List(Of String)

                Dim categoryColumn = New DataView(chartData).ToTable(False, chartData.Columns(0).ColumnName).AsEnumerable
                For Each dataRow As DataRow In categoryColumn
                    dataLabels.Add(dataRow.Item(0).ToString)
                Next

                Labels = dataLabels
                Formatter = Function(value) value.ToString("N")

                If Not HasChartData Then Throw New ChartNoDataException()
            Catch ex As ChartNoDataException
                ChartSubTitle = My.Resources.NoChartDataAvailable
            Catch ex As Exception
                ' clear any series data so that no data image displays
                SeriesCollection = New SeriesCollection() '.clear() throws null except?

                Dim messages = ex.Message.Split(Environment.NewLine.ToCharArray()).
                    Select(Function(message) SharedMethods.TranslateErrorMessage(message))
                Dim errorMessage = String.Join(Environment.NewLine, messages)
                ChartSubTitle = String.Format(My.Resources.Error0, errorMessage)
            End Try
        End Sub

        Public ReadOnly Property LabelRotation As Integer
            Get
                Return SharedMethods.GetLabelRotation(TileSize, Labels.Count)
            End Get
        End Property

        Public Sub Dispose() Implements IDisposable.Dispose
            SharedMethods = Nothing
            SeriesCollection.Clear()
            SeriesCollection = Nothing
            noDataImage = Nothing
            chart.Series.Clear()
            chart.Series = Nothing
            chart = Nothing
        End Sub
    End Class
End Namespace
