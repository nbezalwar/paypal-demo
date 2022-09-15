---
nav_title: "Tipos de identificador de API"
article_title: Tipos de identificador de API
page_order: 2.2
description: "Este artículo de referencia cubre los diferentes tipos de identificadores de API que existen en el tablero de Braze, dónde puede encontrarlos y para qué se utilizan." 
page_type: reference

---

# Tipos de identificador de API

> Esta guía de referencia trata sobre los diferentes tipos de identificadores de API que se pueden encontrar en el panel de Braze, su propósito, dónde se pueden encontrar y cómo se utilizan normalmente. Para obtener información sobre las claves API REST o las claves API de grupo de aplicaciones, consulte la Descripción general de las claves API de [reposo]({{site.baseurl}}/api/api_key/)

Los siguientes identificadores de API se pueden utilizar para acceder a tu plantilla, lienzo, campaña, segmento, envío o tarjeta desde la API externa de Braze. Todos los mensajes deben seguir la codificación [UTF-8][1].

{% tabs %}
{% tab App Ids %}

## La clave API del identificador de la aplicación

La clave API de identificador de aplicación o `app_id` es un parámetro que asocia actividad con una aplicación específica en su grupo de aplicaciones. Designa con qué aplicación dentro del grupo de aplicaciones está interactuando. Por ejemplo, descubrirá que tendrá un `app_id` para su aplicación iOS, un `app_id` para su aplicación Android y un `app_id` para su integración web. En Braze, es posible que tenga varias aplicaciones para la misma plataforma en los distintos tipos de plataforma que admite Braze.

#### ¿Dónde puedo encontrarlo?

Hay dos formas de localizar su `app_id`:

1. Puede encontrar este identificador `app_id` de aplicación o en la consola** de **Developer en **Configuración**. En esta nueva página, en **Identificación**, podrá ver todas las `app_id` que existen para sus aplicaciones.

2. Vaya a **Gestionar ajustes** en **Ajustes**. En esta nueva página, en la pestaña **Configuración**, a mitad de la página, encontrará una "clave API para NOMBRE **** DE APLICACIÓN en **PLATAFORMA**" (p. ej., "clave API para helado en iOS). Esta clave API es su identificador de aplicación.

#### ¿Para qué se puede utilizar?

Los identificadores de aplicaciones en Braze se utilizan al integrar el SDK y también se utilizan para hacer referencia a una aplicación específica en llamadas API REST. Con el `app_id` puede hacer muchas cosas como extraer datos para un evento personalizado que se produjo para una aplicación en particular, recuperar estadísticas de desinstalación, estadísticas de nuevos usuarios, estadísticas de DAU y estadísticas de inicio de sesión para una aplicación en particular.

A veces, es posible que se le solicite un `app_id` pero no está trabajando con una aplicación, ya que es un campo heredado específico de una plataforma específica, puede “omitir” este campo incluyendo cualquier cadena de caracteres como marcador de posición para este parámetro requerido.

#### Múltiples claves API de identificador de aplicación

Durante la configuración del SDK, el caso de uso más común para varias claves API de App Identifier es separar esas claves para variantes de depuración y compilación de versiones.
Para cambiar fácilmente entre varias claves API de App Identifier en sus compilaciones, le recomendamos que cree un `braze.xml` archivo independiente para cada variante de [compilación relevante][3]. Una variante de compilación es una combinación de tipo de compilación y sabor del producto. Tenga en cuenta que, por defecto, un nuevo proyecto Android está configurado con tipos `debug` de compila`release`ción y sin sabores de producto.

Para cada variante de compilación relevante, cree una nueva `braze.xml` para ella en `src/<build variant name>/res/values/`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<resources>
<string name="com_braze_api_key">REPLACE_WITH_YOUR_BUILD_VARIANT_API_KEY</string>
</resources>
```
Cuando se compila la variante de compilación, utilizará la nueva clave API.

{% endtab %}
{% tab Template Ids %}

## Identificador de API de plantilla

Un identificador de API de [plantilla]({{site.baseurl}}/api/endpoints/templates/) o ID de plantilla es una clave lista para usar de Braze para una plantilla determinada dentro del panel. Los ID de plantilla son únicos para cada plantilla y se pueden utilizar para hacer referencia a las plantillas a través de la API. 

Las plantillas son ideales para si tu empresa contrata tus diseños HTML para campañas. Una vez que se han creado las plantillas, ahora tienes una plantilla que no es específica de una campaña, pero que se puede aplicar a una serie de campañas como un boletín informativo.

#### ¿Dónde puedo encontrarlo?
Puede encontrar su ID de plantilla de dos maneras:

1. En el panel, abra **Plantillas y medios** en **Compromiso** y seleccione una plantilla preexistente. Si la plantilla que desea no existe todavía, cree una y guárdela. En la parte inferior de la página de la plantilla individual, podrá encontrar su identificador de API de plantilla.<br>
<br>

2. Braze ofrece una búsqueda de identificadores** de API **adicionales. Aquí puedes buscar rápidamente identificadores específicos. Se puede encontrar en la parte inferior de la pestaña Configuración** de **API en la página de la consola** de **Developer.

#### ¿Para qué se puede utilizar?

- Actualizar plantillas a través de API
- Obtener información sobre una plantilla específica

<br>
{% endtab %}
{% tab Canvas IDs %}

## Identificador de API de lienzo

Un identificador de API de []({{site.baseurl}}/user_guide/engagement_tools/canvas/) lienzo o ID de lienzo es una clave lista para usar de Braze para un determinado lienzo dentro del panel. Los ID de lienzo son únicos para cada lienzo y se pueden utilizar para hacer referencia a los lienzos a través de la API. 

Tenga en cuenta que si tiene un lienzo que tiene variantes, existe un ID de lienzo general, así como ID de lienzo individuales variantes anidados en el lienzo principal. 

#### ¿Dónde puedo encontrarlo?
Puedes encontrar tu ID del lienzo en el panel de control. Abre el **lienzo** en **Compromiso** y selecciona un lienzo preexistente. Si el lienzo que deseas no existe todavía, crea uno y guárdalo. En la parte inferior de una página individual del lienzo, haga clic en **Analizar variantes**. Aparecerá una ventana con el identificador de API del lienzo en la parte inferior.

#### ¿Para qué se puede utilizar?
- Seguimiento de análisis en un mensaje específico
- Obtén estadísticas agregadas de alto nivel sobre el rendimiento del lienzo
- Obtener detalles sobre un lienzo específico
- Con Currents para incorporar datos a nivel de usuario para un enfoque de "imagen más grande" de los lienzos
- Con entrega de activador de API para recopilar estadísticas de mensajes transaccionales

<br>
{% endtab %}
{% tab Campaign IDs %}

## Identificador de API de campaña

Un identificador de API de [campaña]({{site.baseurl}}/user_guide/engagement_tools/campaigns/) o ID de campaña es una clave lista para usar de Braze para una campaña determinada dentro del panel. Los ID de campaña son únicos para cada campaña y se pueden utilizar para hacer referencia a campañas a través de la API. 

Tenga en cuenta que si tiene una campaña que tiene variantes, hay tanto un ID de campaña general como ID de campaña de variante individual anidados en la campaña principal. 

#### ¿Dónde puedo encontrarlo?
Puedes encontrar tu ID de campaña de dos maneras:

1. En el panel, abra **Campañas** en **Compromiso** y seleccione una campaña preexistente. Si la campaña que deseas aún no existe, crea una y guárdala. En la parte inferior de la página de campaña individual, podrás encontrar tu identificador de API de **campaña**.<br>
<br>

2. Braze ofrece una búsqueda de identificadores** de API **adicionales. Aquí puedes buscar rápidamente identificadores específicos. Puede encontrarlo en la parte inferior de la pestaña Configuración** de **API en la consola de **Developer**.

#### ¿Para qué se puede utilizar?
- Seguimiento de análisis en un mensaje específico
- Obtenga estadísticas agregadas de alto nivel sobre el rendimiento de la campaña
- Obtener detalles sobre una campaña específica
- Con Currents para incorporar datos de nivel de usuario para un enfoque de "imagen más amplia" de las campañas
- Con entrega activada por API para recopilar estadísticas de mensajes transaccionales
- Para [buscar una campaña]({{site.baseurl}}/user_guide/engagement_tools/campaigns/managing_campaigns/search_campaigns/#search-syntax) específica en la página **Campañas** utilizando el filtro `api_id:YOUR_API_ID`

<br>
{% endtab %}
{% tab Segment IDs %}

## Identificador de API de segmento

Un identificador de API de [segmento]({{site.baseurl}}/user_guide/engagement_tools/segments/) o ID de segmento es una clave lista para usar de Braze para un segmento determinado dentro del panel. Los ID de segmento son únicos para cada segmento y se pueden utilizar para hacer referencia a segmentos a través de la API. 

#### ¿Dónde puedo encontrarlo?
Puede encontrar su ID de segmento de dos maneras:

1. En el panel, abra **Segmentos** en **Compromiso** y seleccione un segmento preexistente. Si el segmento que desea aún no existe, cree uno y guárdelo. En la parte inferior de la página de segmento individual, podrá encontrar su identificador de API de segmento. <br>
<br>

2. Braze ofrece una búsqueda de identificadores** de API **adicionales. Aquí puedes buscar rápidamente identificadores específicos. Se puede encontrar en la parte inferior de la pestaña Configuración** de **API en la página de la consola** de **Developer.

#### ¿Para qué se puede utilizar?
- Obtener detalles sobre un segmento específico
- Recuperar análisis de un segmento específico
- Extraer cuántas veces se grabó un evento personalizado para un segmento en particular
- Especificar y enviar una campaña a miembros de un segmento desde la API

{% endtab %}
{% tab Card IDs %}

## Identificador de API de tarjeta

Un identificador de API de tarjeta o ID de tarjeta es una clave lista para usar de Braze para una tarjeta de fuente de noticias determinada dentro del panel. Los ID de tarjeta son únicos para cada tarjeta de fuente[ de ]({{site.baseurl}}/user_guide/engagement_tools/news_feed/)noticias y se pueden utilizar para hacer referencia a las tarjetas a través de la API. 

#### ¿Dónde puedo encontrarlo?
Puede encontrar el ID de su tarjeta de dos maneras:

1. En el panel, abra Fuente de **** noticias en **Compromiso** y seleccione una Fuente de noticias preexistente. Si la fuente de noticias que desea aún no existe, cree una y guárdela. En la parte inferior de la página de noticias individuales, podrá encontrar su identificador único de API de tarjeta. <br>
<br>

2. Braze ofrece una búsqueda de identificadores** de API **adicionales. Aquí puedes buscar rápidamente identificadores específicos. Se puede encontrar en la parte inferior de la pestaña Configuración** de **API en la página de la consola** de **Developer.

#### ¿Para qué se puede utilizar?
- Recuperar información relevante en una tarjeta
- Seguimiento de eventos relacionados con tarjetas de contenido y participación

<br>
{% endtab %}
{% tab Send IDs %}

## Enviar identificador

Un identificador de envío o ID de envío es una clave generada por Braze o creada por usted para un determinado envío de mensaje bajo el cual se debe realizar un seguimiento de los análisis. El identificador de envío le permite retirar análisis para una instancia específica de una campaña enviada a través del [`sends/data_series`]({{site.baseurl}}/api/endpoints/export/campaigns/get_send_analytics/) punto final.

#### ¿Dónde puedo encontrarlo?

Las campañas de activación de API y API que se envían como difusión generarán automáticamente un identificador de envío si no se proporciona un identificador de envío. Si desea especificar su propio identificador de envío, primero tendrá que crear uno a través del [`sends/id/create`]({{site.baseurl}}/api/endpoints/messaging/send_messages/post_create_send_ids/) punto final. El identificador debe tener todos los caracteres ASCII y como máximo 64 caracteres. Puedes reutilizar un identificador de envío en varios envíos de la misma campaña si deseas agrupar los análisis de esos envíos juntos.

#### ¿Para qué se puede utilizar?
Envía y realiza un seguimiento del rendimiento de los mensajes de forma programática, sin crear campañas para cada envío.

<br>
{% endtab %}
{% endtabs %}

[1]: https://en.wikipedia.org/wiki/UTF-8
[3]: https://developer.android.com/studio/build/build-variants.html
