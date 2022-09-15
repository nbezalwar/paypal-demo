---
page_order: 2.4
nav_title: Parámetros
article_title: Parámetros de API
layout: glossary_page
glossary_top_header: "Parámetros"
glossary_top_text: "Utilice estos parámetros para definir sus solicitudes de API. Aunque los parámetros que necesita se enumeran en los criterios de valoración, esto debería darle más información sobre sus matices y otras especificaciones."

description: "Este glosario cubre en detalle los parámetros implicados en la realización de solicitudes de API." 
page_type: glossary

glossaries:
  - name: Clave de API REST de grupo de aplicaciones
    description: El <code>api_key</code> indica el título de la aplicación con el que están asociados los datos de esta solicitud y autentica al solicitante como alguien que puede enviar mensajes a la aplicación. Debe incluirse con cada solicitud como encabezado de autorización HTTP. Se puede encontrar en la sección Consola<strong> de </strong>desarrollador del panel de Braze.
    field: "api_key"
  - name: Identificador de aplicación
    description: Si desea enviar push a un conjunto de tokens de dispositivo (en lugar de usuarios), debe indicar en nombre de qué aplicación específica está enviando mensajes. En ese caso, proporcionará el identificador de aplicación adecuado en un objeto de tokens. Se puede encontrar en la sección Consola<strong> de </strong>desarrollador del panel de Braze.
    field: "app_id"
  - name: ID de usuario externo
    description: Identificador único para enviar un mensaje a usuarios específicos. Este identificador debe ser el mismo que el que estableció en el SDK de Braze. Solo puede dirigirse a usuarios para mensajes que ya hayan sido identificados a través del SDK o la API de usuario. Se permite un máximo de 50 ID de usuario externo en una solicitud. <br>
 <br>
 Para los puntos finales de activación de campaña, si proporciona este campo, los criterios se estratificarán con los segmentos de la campaña y solo los usuarios que estén en la lista de ID de usuario externo y el segmento de la campaña recibirán el mensaje.
    field: "external_user_ids"
  - name: Identificador de segmento
    description: El <code>segment_id</code> indica el segmento al que se debe enviar el mensaje. Puede encontrar un identificador de segmento para cada uno de los segmentos que ha creado en la sección Consola<strong> de </strong>desarrollador del panel de Braze. <br>
 <br>
 Para los terminales de mensaje, si proporciona un identificador de segmento y una lista de ID de usuario externo en una sola solicitud de mensajería, los criterios se estratificarán y solo los usuarios que estén en la lista de ID de usuario externo y el segmento proporcionado recibirán el mensaje.
    field: "segment_id"
  - name: Identificador de campaña
    description: Para terminales de mensajería, <code>campaign_id</code> indica la campaña API en la que se debe realizar un seguimiento de los análisis de un mensaje. Puede encontrar un identificador de campaña para cada una de las campañas que ha creado en la sección Consola<strong> de </strong>desarrolladores del tablero de Braze. Si proporciona un identificador de campaña en el cuerpo de la solicitud, debe proporcionar un <code>message_variation_id</code> en cada uno de los objetos de mensaje que indican la variante representada de su campaña. <br>
 <br>
 Para los puntos finales de activación de campaña, <code>campaign_id</code> indica el ID de API de la campaña que se va a activar. Este campo es obligatorio para todas las solicitudes de punto final de activación.
    field: "campaign_id"
  - name: Identificador de lienzo
    description: Para los puntos finales de activación del lienzo, <code>canvas_id</code> indica el identificador del lienzo que se va a activar o programar. Este campo es obligatorio para todas las solicitudes de punto final de activación.
    field: "canvas_id"
  - name: Enviar identificador
    description: Para los terminales de mensajería, el <code>send_id</code> indica el envío en virtud del cual se debe realizar un seguimiento de los análisis de un mensaje. El le <code>send_id</code> permite extraer análisis para una instancia específica de una campaña enviada a través del <code>sends/data_series</code> punto final. Las campañas API y API activadoras que se envían como difusión generarán automáticamente un identificador de envío si no se proporciona un identificador de envío. <br>
 <br>
 Si desea especificar su propio <code>send_id</code>, primero tendría que crear uno a través del <code>sends/id/create</code> punto final. El <code>send_id</code> debe tener todos los caracteres ASCII y como máximo 64 caracteres.  Puedes reutilizar un identificador de envío en varios envíos de la misma campaña si deseas agrupar los análisis de esos envíos juntos. <br>
 <br>
 Tenga en cuenta que el <code>send_id</code> seguimiento no está disponible para los correos electrónicos enviados a través de Mailjet. <br>
 <br>
 Las conversiones de campaña se atribuyen al último seguimiento <code>send_id</code> que el usuario recibió de esa campaña, a menos que el último envío que el usuario recibió no haya sido rastreado.
    field: "send_id"
  - name: Propiedades del activador
    description: "Al utilizar uno de los puntos finales para enviar una campaña con entrega activada por API, puede proporcionar un mapa de claves y valores para personalizar su mensaje. Si realiza una solicitud de API que contiene un objeto en <code>\"trigger_properties\"</code>, se puede hacer referencia a los valores de ese objeto en su plantilla de mensaje bajo el espacio de <code>api_trigger_properties</code> nombres. <br>
 <br>
 Por ejemplo, una solicitud con <code>\"trigger_properties\" : {\"product_name\" : \"shoes\", \"product_price\" : 79.99}</code> podría añadir la palabra \"zapatas\" al mensaje añadiendo <code>{{api_trigger_properties.${product_name}}}</code>."
    field: "trigger_properties"
  - name: Propiedades de la entrada del lienzo
    description: "Cuando utilices uno de los endpoints para activar o programar un lienzo a través de la API, puedes proporcionar un mapa de claves y valores para personalizar los mensajes enviados por los primeros pasos de tu lienzo, en el espacio de <code>\"canvas_entry_properties\"</code> nombres. <br>
 <br>
 Por ejemplo, una solicitud con <code>\"canvas_entry_properties\" : {\"product_name\" : \"shoes\", \"product_price\" : 79.99}</code> podría añadir la palabra \"zapatas\" a un mensaje añadiendo <code>{{canvas_entry_properties.${product_name}}}</code>."
    field: "canvas_entry_properties"
  - name: Difusión
    description: "Al enviar un mensaje a un segmento o público de campaña utilizando un punto final de API, Braze requiere que definas explícitamente si tu mensaje es una \"difusión\" a un gran grupo de usuarios mediante la inclusión de un <code>broadcast</code> booleano en la llamada API. Es decir, si tienes la intención de enviar un mensaje de API a todo el segmento al que se dirige una campaña o lienzo, debes incluirlo <code>broadcast: true</code> en tu llamada a la API. <br>
<br>
Difusión es un campo obligatorio y el valor predeterminado establecido por Braze cuando se realiza una campaña o lienzo es <code>broadcast: false</code>. No puede tener ambas <code>broadcast: true</code> y una <code>recipients</code> lista especificada. Si el <code>broadcast</code> indicador se establece en verdadero y se proporciona una lista explícita de destinatarios, el punto final de la API devolverá un error. Del mismo modo, si se incluye <code>broadcast: false</code> y no se proporciona una lista de destinatarios, se producirá un error. 
    
    <br>
<br>
Ten cuidado al configurar <code>broadcast: true</code>, ya que esta marca puede hacer que envíes tu campaña o lienzo a un público más grande de lo esperado. El <code>broadcast</code> indicador es necesario para proteger contra envíos accidentales a grandes grupos de usuarios."
    field: "broadcast"
    
---
