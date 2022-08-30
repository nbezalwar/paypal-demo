---
nav_title: Cartes de contenu
article_title: Intégration des cartes de contenu pour Cordova
platform: 
  - Cordova
  - iOS
  - Android
page_order: 3
channel: cartes de contenu
page_type: reference
description: "Cet article explique comment se lancer dans les cartes de contenu pour Cordova."

---

# Cartes de contenu pour l’intégration Cordova

Pour se lancer dans les cartes de contenu, les SDK Braze incluent un flux de cartes par défaut. Pour afficher le flux de cartes, vous pouvez utiliser la méthode `AppboyPlugin.launchContentCards()`.

Le flux de cartes par défaut inclus avec le SDK Braze traitera toutes les analytiques de traçages, d’abandons et de rendu des cartes de contenu d’un utilisateur.

## Personnalisation

Vous pouvez utiliser ces méthodes supplémentaires pour créer un flux de cartes de contenu personnalisé dans votre application :

|Méthode | Description |
|---|---|
|`AppboyPlugin.requestContentCardsRefresh()`|Demande les dernières cartes de contenu du serveur SDK Braze.|
|`AppboyPlugin.getContentCardsFromServer(successCallback, errorCallback)`|Récupère les cartes de contenu du SDK Braze. La dernière liste des cartes du serveur sera affichée.|
|`AppboyPlugin.getContentCardsFromCache(successCallback, errorCallback)`|Récupère les cartes de contenu du SDK Braze. La dernière liste des cartes du cache sera affichée.|
|`AppboyPlugin.logContentCardClicked(cardId)`|Enregistre un clic pour l’ID de carte de contenu donné.|
|`AppboyPlugin.logContentCardImpression(cardId)`|Enregistre une impression pour l’ID de carte de contenu donné.|
|`AppboyPlugin.logContentCardDismissed(cardId)`|Enregistre un abandon pour l’ID de carte de contenu donné.|
{: .reset-td-br-1 .reset-td-br-2}
