---
nav_title: Style personnalisé
article_title: Style personnalisé de message in-app pour le Web
platform: Web
channel: messages in-app
page_order: 3
page_type: reference
description: "Cet article couvre le style personnalisé des messages in-app pour votre application Web."

---

# Style personnalisé

Les éléments de l’IU de Braze sont dotés d’un aspect et d’une convivialité par défaut qui créent une expérience de message in-app neutre et visent à assurer la cohérence avec d’autres plateformes mobiles Braze. Les styles par défaut de Braze sont définis en CSS au sein du SDK Braze. En écrasant des styles sélectionnés dans votre application, vous pouvez personnaliser nos types de messages in-app standard avec vos propres images de fond, des familles de polices, des styles, des tailles, des animations, et bien plus encore. Par exemple, ce qui suit est un exemple de remplacement qui entraînera la mise en italique des en-têtes d’un message in-app :

```css
  body .ab-in-app-message .ab-message-header {
    font-style: italic;
  }
```

Consultez les [JSDocs][2] pour plus d’informations.

## Position verticale par défaut du message in-app

Par défaut, les messages in-app sont affichés en utilisant `z-index: 9001`. Ceci est configurable à l’aide de l’`inAppMessageZIndex `[ option d’initialisation ][41] dans le cas où le éléments de style de votre site Internet auraient des valeurs plus élevées que cela.

```javascript
braze.initialize("YOUR-API-KEY", {
    baseUrl: "YOUR-API-ENDPOINT",
    inAppMessageZIndex: 12000
});
```

{% alert important %}
Cette option a été introduite dans SDK Web v3.3.0. Les SDK plus anciens doivent être mises à niveau pour utiliser cette option.
{% endalert %}

[2]: https://js.appboycdn.com/web-sdk/latest/doc/classes/braze.inappmessage.html
[15]: https://fontawesome.com/?from=io
[41]: https://js.appboycdn.com/web-sdk/latest/doc/modules/braze.html#initializationoptions
