---
nav_title: Réseau en mode hors connexion
article_title: Réseau en mode hors connexion pour Android et FireOS
platform: 
  - Android
  - FireOS
page_order: 3
description: "Cet article de référence explique comment intégrer le réseau en mode hors connexion pour votre application Android ou FireOS."

---

# Réseau en mode hors connexion

Le [Réseau en mode hors connexion][1] est une fonctionnalité facultative qui suspend ou reprend les demandes de réseau sortant du SDK Braze à tout moment pendant l’exécution. Les événements ne sont pas perdus pendant l’état hors connexion.

## Exemple d’utilisation

Pour activer le réseau en mode hors connexion dans le SDK Braze, voir l’exemple suivant :

{% tabs %}
{% tab JAVA %}

```java
Braze.setOutboundNetworkRequestsOffline(true);
```

{% endtab %}
{% tab KOTLIN %}

```kotlin
Braze.setOutboundNetworkRequestsOffline(true)
```

{% endtab %}
{% endtabs %}

[1]: https://appboy.github.io/appboy-android-sdk/kdoc/braze-android-sdk/com.appboy/-appboy/set-outbound-network-requests-offline.html
