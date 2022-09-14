---
nav_title: "API-Kennungstypen"
article_title: API-Kennungstypen
page_order: 2.2
description: "Dieser Referenzartikel behandelt die verschiedenen Arten von API-Identifikatoren, die im Braze-Dashboard vorhanden sind, wo Sie sie finden können und wofür sie verwendet werden." 
page_type: reference

---

# Typen von API-Kennungen

> Dieses Referenzhandbuch behandelt die verschiedenen Arten von API-Identifikatoren, die im Braze-Dashboard zu finden sind, ihren Zweck, wo Sie sie finden können und wie sie normalerweise verwendet werden. Informationen zu REST-API-Schlüsseln oder App-Gruppen-API-Schlüsseln finden Sie in der Übersicht über den [Rest-API-Schlüssel]({{site.baseurl}}/api/api_key/)

Die folgenden API-Kennungen können verwendet werden, um über die externe API von Braze auf Ihre Vorlage, Ihren Canvas, Ihre Kampagne, Ihr Segment, Ihren Versand oder Ihre Karte zuzugreifen. Alle Nachrichten sollten der [UTF-8][1]-Codierung folgen.

{% tabs %}
{% tab App Ids %}

## Der API-Schlüssel der App-Kennung

Der API-Schlüssel der App-Kennung oder `app_id` ist ein Parameter, der eine Aktivität mit einer bestimmten App in Ihrer App-Gruppe verknüpft. Sie gibt an, mit welcher App innerhalb der App-Gruppe Sie interagieren. Sie werden beispielsweise feststellen, dass Sie einen `app_id` für Ihre iOS-App, einen `app_id` für Ihre Android-App und einen `app_id` für Ihre Webintegration haben werden. Bei Braze stellen Sie möglicherweise fest, dass Sie mehrere Apps für dieselbe Plattform über die verschiedenen Plattformtypen hinweg haben, die Braze unterstützt.

#### Wo finde ich sie?

Es gibt zwei Möglichkeiten, Ihren zu finden`app_id`:

1. Diese `app_id` oder Anwendungskennung finden Sie in der **Developer Console** unter **Einstellungen**. Auf dieser neuen Seite können**Sie unter **Identifikation alle für Ihre Apps `app_id` vorhandenen sehen.

2. Gehen Sie zu Einstellungen **** verwalten unter **Einstellungen**. Auf dieser neuen Seite finden Sie auf der Registerkarte **Einstellungen** in der Mitte der Seite einen „API-Schlüssel für **APP-NAME** auf **PLATTFORM**“ (z. B. „API-Schlüssel für Eiscreme auf iOS). Dieser API-Schlüssel ist Ihre Anwendungskennung.

#### Wofür kann es verwendet werden?

App-Kennungen bei Braze werden bei der Integration des SDK verwendet und werden auch verwendet, um auf eine bestimmte App in REST-API-Aufrufen zu verweisen. Mit können `app_id` Sie viele Dinge tun, wie z. B. Daten für ein benutzerdefiniertes Ereignis abrufen, das für eine bestimmte App aufgetreten ist, Deinstallationsstatistiken, neue Benutzerstatistiken, DAU-Statistiken und Sitzungsstartstatistiken für eine bestimmte App abrufen.

Manchmal werden Sie möglicherweise zur Eingabe eines aufgefordert, `app_id` aber Sie arbeiten nicht mit einer App. Da es sich um ein Legacy-Feld handelt, das für eine bestimmte Plattform spezifisch ist, können Sie dieses Feld „auslassen“, indem Sie eine beliebige Zeichenfolge als Platzhalter für diesen erforderlichen Parameter einfügen.

#### Mehrere API-Schlüssel für die App-Kennung

Während der SDK-Einrichtung besteht der häufigste Anwendungsfall für mehrere App Identifier API-Schlüssel darin, diese Schlüssel für Debug- und Release-Build-Varianten zu trennen.
Um einfach zwischen mehreren App Identifier API-Schlüsseln in Ihren Builds zu wechseln, empfehlen wir, eine separate `braze.xml` Datei für jede relevante [Build-Variante zu erstellen][3]. Eine Build-Variante ist eine Kombination aus Build-Typ und Produktgeschmack. Beachten Sie, dass standardmäßig ein neues Android-Projekt mit konfiguriert ist `debug` und Typen ohne Produktgeschmacksstoffe `release` erstellt.

Erstellen Sie für jede relevante Build-Variante eine neue `braze.xml` in `src/<build variant name>/res/values/`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<resources>
<string name="com_braze_api_key">REPLACE_WITH_YOUR_BUILD_VARIANT_API_KEY</string>
</resources>
```
Wenn die Build-Variante kompiliert ist, verwendet sie den neuen API-Schlüssel.

{% endtab %}
{% tab Template Ids %}

## Vorlagen-API-Kennung

Eine [Vorlagen]({{site.baseurl}}/api/endpoints/templates/)-API-Kennung oder Vorlagen-ID ist ein sofort einsatzbereiter Schlüssel von Braze für eine bestimmte Vorlage innerhalb des Dashboards. Vorlagen-IDs sind für jede Vorlage eindeutig und können verwendet werden, um Vorlagen über die API zu referenzieren. 

Vorlagen eignen sich hervorragend, wenn dein Unternehmen deine HTML-Designs für Kampagnen ausgibt. Sobald die Vorlagen erstellt wurden, haben Sie jetzt eine Vorlage, die nicht spezifisch für eine Kampagne ist, sondern auf eine Reihe von Kampagnen wie einen Newsletter angewendet werden kann.

#### Wo finde ich sie?
Sie können Ihre Vorlagen-ID auf zwei Arten finden:

1. Öffnen Sie im Dashboard **Vorlagen und Medien** unter **Engagement** und wählen Sie eine bereits vorhandene Vorlage aus. Wenn die gewünschte Vorlage noch nicht existiert, erstellen Sie eine und speichern Sie sie. Unten auf der einzelnen Vorlagenseite finden Sie Ihre Vorlagen-API-Kennung.<br>
<br>

2. Braze bietet eine Suche nach **zusätzlichen API-Identifikatoren** an. Hier können Sie schnell nach bestimmten Kennungen suchen. Sie finden sie unten auf der Registerkarte **API-Einstellungen** auf der Seite **Developer Console**.

#### Wofür kann es verwendet werden?

- Vorlagen über API aktualisieren
- Informationen auf einer bestimmten Vorlage erfassen

<br>
{% endtab %}
{% tab Canvas IDs %}

## Canvas API-Kennung

Eine [Canvas]({{site.baseurl}}/user_guide/engagement_tools/canvas/)-API-Kennung oder Canvas-ID ist ein sofort einsatzbereiter Schlüssel von Braze für einen bestimmten Canvas innerhalb des Dashboards. Canvas-IDs sind für jeden Canvas eindeutig und können verwendet werden, um Canvases über die API zu referenzieren. 

Wenn Sie einen Canvas mit Varianten haben, gibt es eine Canvas-ID insgesamt sowie einzelne Canvas-IDs, die unter dem Haupt-Canvas verschachtelt sind. 

#### Wo finde ich sie?
Sie finden Ihre Canvas-ID im Dashboard. Öffnen Sie **Canvas** unter **Engagement** und wählen Sie eine bereits vorhandene Leinwand aus. Wenn die gewünschte Leinwand noch nicht vorhanden ist, erstellen Sie eine und speichern Sie sie. Klicken Sie unten auf einer einzelnen Canvas-Seite auf Varianten **analysieren**. Es erscheint ein Fenster mit der Canvas API Identifier unten.

#### Wofür kann es verwendet werden?
- Analysen einer bestimmten Nachricht verfolgen
- Holen Sie sich hochrangige aggregierte Statistiken auf Canvas-Performance
- Greifen Sie Details auf einem bestimmten Canvas
- Mit Currents, um Daten auf Benutzerebene für einen „größeren Bild“-Ansatz für Leinwände einzubringen
- Mit API-Trigger-Zustellung, um Statistiken für Transaktionsnachrichten zu sammeln

<br>
{% endtab %}
{% tab Campaign IDs %}

## Kampagnen-API-Kennung

Eine [Kampagnen]({{site.baseurl}}/user_guide/engagement_tools/campaigns/)-API-Kennung oder Kampagnen-ID ist ein sofort einsatzbereiter Schlüssel von Braze für eine bestimmte Kampagne im Dashboard. Kampagnen-IDs sind für jede Kampagne eindeutig und können verwendet werden, um Kampagnen über die API zu referenzieren. 

Beachten Sie, dass, wenn Sie eine Kampagne mit Varianten haben, sowohl eine Gesamtkampagnen-ID als auch einzelne Kampagnen-IDs für Varianten unter der Hauptkampagne verschachtelt sind. 

#### Wo finde ich sie?
Sie können Ihre Kampagnen-ID auf zwei Arten finden:

1. Öffnen Sie im Dashboard **Kampagnen** unter **Engagement** und wählen Sie eine bereits vorhandene Kampagne aus. Wenn die gewünschte Kampagne noch nicht existiert, erstellen Sie eine und speichern Sie sie. Unten auf der Seite für einzelne Kampagnen finden Sie Ihre **Kampagnen-API-Kennung**.<br>
<br>

2. Braze bietet eine Suche nach **zusätzlichen API-Identifikatoren** an. Hier können Sie schnell nach bestimmten Kennungen suchen. Diese finden Sie unten auf der Registerkarte **API-Einstellungen** in der **Developer Console**.

#### Wofür kann es verwendet werden?
- Analysen einer bestimmten Nachricht verfolgen
- Erhalten Sie allgemeine aggregierte Statistiken zur Kampagnenleistung
- Holen Sie sich Details zu einer bestimmten Kampagne
- Mit Currents, um Daten auf Benutzerebene für einen „größeren“ Ansatz bei Kampagnen einzubringen
- Mit API-getriggerter Lieferung, um Statistiken für Transaktionsnachrichten zu sammeln
- So [suchen Sie mithilfe des Filters]({{site.baseurl}}/user_guide/engagement_tools/campaigns/managing_campaigns/search_campaigns/#search-syntax) auf der Seite **Kampagnen nach einer bestimmten Kampagne** `api_id:YOUR_API_ID`

<br>
{% endtab %}
{% tab Segment IDs %}

## Segment-API-Kennung

Eine [Segment]({{site.baseurl}}/user_guide/engagement_tools/segments/)-API-Kennung oder Segment-ID ist ein sofort einsatzbereiter Schlüssel von Braze für ein bestimmtes Segment im Dashboard. Segment-IDs sind für jedes Segment eindeutig und können verwendet werden, um Segmente über die API zu referenzieren. 

#### Wo finde ich sie?
Sie können Ihre Segment-ID auf zwei Arten finden:

1. Öffnen Sie im Dashboard **Segmente unter **Engagement** und wählen Sie ein bereits bestehendes** Segment aus. Wenn das gewünschte Segment noch nicht existiert, erstellen Sie eines und speichern Sie es. Unten auf der Seite mit den einzelnen Segmenten finden Sie Ihre Segment-API-Kennung. <br>
<br>

2. Braze bietet eine Suche nach **zusätzlichen API-Identifikatoren** an. Hier können Sie schnell nach bestimmten Kennungen suchen. Sie finden sie unten auf der Registerkarte **API-Einstellungen** auf der Seite **Developer Console**.

#### Wofür kann es verwendet werden?
- Details zu einem bestimmten Segment abrufen
- Abrufen von Analysen eines bestimmten Segments
- Abrufen, wie oft ein benutzerdefiniertes Ereignis für ein bestimmtes Segment aufgezeichnet wurde
- Festlegen und Senden einer Kampagne an Mitglieder eines Segments innerhalb der API

{% endtab %}
{% tab Card IDs %}

## Karten-API-Kennung

Eine Karten-API-Kennung oder Karten-ID ist ein sofort einsatzbereiter Schlüssel von Braze für eine bestimmte Newsfeed-Karte im Dashboard. Karten-IDs sind für jede [News Feed]({{site.baseurl}}/user_guide/engagement_tools/news_feed/)-Karte eindeutig und können verwendet werden, um Karten über die API zu referenzieren. 

#### Wo finde ich sie?
Sie können Ihre Karten-ID auf eine von zwei Arten finden:

1. Öffnen Sie im Dashboard **News Feed** unter **Engagement** und wählen Sie einen bereits vorhandenen News Feed aus. Wenn der gewünschte Newsfeed noch nicht existiert, erstellen Sie einen und speichern Sie ihn. Unten auf der einzelnen Newsfeed-Seite finden Sie Ihre eindeutige Karten-API-Kennung. <br>
<br>

2. Braze bietet eine Suche nach **zusätzlichen API-Identifikatoren** an. Hier können Sie schnell nach bestimmten Kennungen suchen. Sie finden sie unten auf der Registerkarte **API-Einstellungen** auf der Seite **Developer Console**.

#### Wofür kann es verwendet werden?
- Relevante Informationen auf einer Karte abrufen
- Verfolgen Sie Ereignisse im Zusammenhang mit Content Cards und Engagement

<br>
{% endtab %}
{% tab Send IDs %}

## Kennung senden

Ein Send Identifier oder Send ID ist ein Schlüssel, der entweder von Braze generiert oder von Ihnen für eine bestimmte Nachricht erstellt wird, unter der die Analyse verfolgt werden sollte. Mit der Sendekennung können Sie Analysen für eine bestimmte Instanz einer Kampagne abrufen, die über den [`sends/data_series`]({{site.baseurl}}/api/endpoints/export/campaigns/get_send_analytics/) Endpunkt gesendet wird.

#### Wo finde ich sie?

API- und API-Trigger-Kampagnen, die als Broadcast gesendet werden, generieren automatisch eine Sendekennung, wenn keine Sendekennung bereitgestellt wird. Wenn Sie Ihre eigene Sendekennung angeben möchten, müssen Sie zunächst eine über den [`sends/id/create`]({{site.baseurl}}/api/endpoints/messaging/send_messages/post_create_send_ids/) Endpunkt erstellen. Die Kennung muss alle ASCII-Zeichen und höchstens 64 Zeichen lang sein. Sie können eine Sendekennung für mehrere Sendungen derselben Kampagne wiederverwenden, wenn Sie die Analysen dieser Sendungen zusammen gruppieren möchten.

#### Wofür kann es verwendet werden?
Sende und verfolge die Nachrichtenleistung programmatisch, ohne Kampagnenerstellung für jeden Sendevorgang.

<br>
{% endtab %}
{% endtabs %}

[1]: https://en.wikipedia.org/wiki/UTF-8
[3]: https://developer.android.com/studio/build/build-variants.html
