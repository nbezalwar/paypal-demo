---
nav_title: Livraison de messages in-app
article_title: Livraison de messages in-app pour le Web
platform: Web
channel: messages in-app
page_order: 4
page_type: reference
description: "Cet article décrit la livraison de messages in-app via le SDK Braze, comme l’affichage manuel de messages in-app ou l’envoi de messages d’intention de sortie."

---

# Livraison de messages in-app

## Types de déclencheurs

Notre produit de messages in-app vous permet de déclencher un affichage de messages in-app suite à plusieurs types d’événements différents : `Any Purchase`, `Specific Purchase`, `Session Start`, `Custom Event` et `Push Click`. En outre, les déclencheurs `Specific Purchase` et `Custom Event` contiennent des filtres de propriétés robustes.

{% alert note %}
Les messages in-app déclenchés ne fonctionnent qu’avec des événements personnalisés enregistrés via le SDK et non par le biais des API REST. Si vous travaillez avec une application Web, consultez la procédure concernant la manière d’[enregistrer les événements personnalisés]({{site.baseurl}}/developer_guide/platform_integration_guides/web/analytics/tracking_custom_events/#tracking-custom-events).
{% endalert %}

## Sémantiques de livraison

Tous les messages in-app qu’un utilisateur est admissible à recevoir sont automatiquement téléchargés sur l’appareil de l’utilisateur ou son navigateur lors d’un événement de démarrage de session et déclenchés conformément aux règles de livraison du message. Consultez notre [documentation de cycle de vie de session][10] pour plus d’informations sur les sémantiques de début de session du SDK.

## Intervalle de temps minimum entre les déclencheurs

Par défaut, nos limites de débit des messages in-app sont à une fois toutes les 30 secondes afin de garantir une expérience utilisateur de qualité. Pour remplacer cette valeur, vous pouvez transmettre l’option de configuration `minimumIntervalBetweenTriggerActionsInSeconds` à votre fonction [`initialize`][9] :

```javascript
// Sets the minimum time interval between triggered in-app messages to 5 seconds instead of the default 30
braze.initialize('YOUR-API-KEY', { minimumIntervalBetweenTriggerActionsInSeconds: 5 })
```

## Affichage manuel de messages in-app

Si vous ne souhaitez pas que votre site affiche immédiatement les nouveaux messages in-app lorsqu’ils sont déclenchés, vous pouvez désactiver l’affichage automatique et enregistrer vos propres abonnements d’affichage. 

Tout d’abord, trouvez et supprimez l’appel à `braze.automaticallyShowInAppMessages()` à partir de votre extrait de code de chargement. Créez ensuite votre propre logique pour gérer de manière personnalisée un message in-app de déclenchement, dans lequel vous affichez ou n’affichez pas le message. 

```javascript
braze.subscribeToInAppMessage(function(inAppMessage) {
  // Display the in-app message. You could defer display here by pushing this message to code within your own application.
  // If you don't want to use Braze's built-in display capabilities, you could alternatively pass the in-app message to your own display code here.
  
  if ( should_show_the_message_according_to_your_custom_logic ) {
      braze.showInAppMessage(inAppMessage);
  } else {
      // do nothing
  }
});
```

{% alert important %}
Si vous ne retirez pas `braze.automaticallyShowInAppMessages()` de votre site Internet lorsque vous appelez également `braze.showInAppMessage`, le message peut être affiché deux fois.
{% endalert %}

Le paramètre `inAppMessage` sera une sous-classe [`braze.InAppMessage`][2] ou un objet [`braze.ControlMessage`][8], chacun ayant des méthodes différentes d’abonnement aux événements de cycle de vie. Consultez les [JSDocs][2] pour une documentation complète.

Un seul message in-app [`Modal`][17] ou [`Full`][41] peut être affiché à un instant donné. Si vous essayez de montrer un deuxième message modal ou complet, alors qu’un s’affiche déjà, `braze.showInAppMessage` renverra « faux » et le deuxième message ne s’affichera pas.

## Messages in-app locaux

Les messages in-app peuvent également être créés dans l’application et affichés localement en temps réel. Toutes les options de personnalisation disponibles sur le tableau de bord sont également disponibles localement. Ceci est particulièrement utile pour afficher les messages que vous souhaitez déclencher dans l’application en temps réel. Cependant, l’analytique de ces messages créés localement ne sera pas disponible dans le tableau de bord de Braze.

```javascript
  // Displays a slideup type in-app message.
  var message = new braze.SlideUpMessage("Welcome to Braze! This is an in-app message.");
  message.slideFrom = braze.InAppMessage.SlideFrom.TOP;
  braze.showInAppMessage(message);
```

## Messages d’intention de sortie

Les messages in-app d’intention de sortie apparaissent lorsque les visiteurs sont sur le point de quitter votre site. Ils offrent une autre possibilité de communiquer des informations importantes aux utilisateurs tout en n’interrompant pas leur expérience de votre site. 

Pour envoyer ces messages, commencez par ajouter une bibliothèque d’intention de sortie, telle que cette [bibliothèque open source][50], sur votre site Internet. Utilisez ensuite l’extrait de code suivant pour enregistrer « l’intention de sortie » en tant qu’événement personnalisé. Les campagnes de messages in-app peuvent alors être créées dans le tableau de bord en utilisant « l’intention de sortie » comme événement personnalisé déclencheur.

```javascript
  var _ouibounce = ouibounce(false, {
    callback: function() { braze.logCustomEvent('exit intent'); }
  });
```


[2]: https://js.appboycdn.com/web-sdk/latest/doc/classes/braze.inappmessage.html
[8]: https://js.appboycdn.com/web-sdk/latest/doc/classes/braze.controlmessage.html
[9]: https://js.appboycdn.com/web-sdk/latest/doc/modules/braze.html#initialize
[10]: {{site.baseurl}}/developer_guide/platform_integration_guides/web/analytics/tracking_sessions/#session-lifecycle
[17]: {{site.baseurl}}/developer_guide/platform_integration_guides/web/in_app_messaging/#modal-in-app-messages
[41]: {{site.baseurl}}/developer_guide/platform_integration_guides/web/in_app_messaging/#full-in-app-messages
[50]: https://github.com/carlsednaoui/ouibounce
