---
nav_title: Accessibilité
article_title: Accessibilité pour Android et FireOS
page_order: 4
platform: 
  - Android
  - FireOS
description: "Cet article de référence explique comment implémenter des fonctionnalités d’accessibilité spécifiques au SDK Android, telles que le TalkBack du message in-app dans votre application Android ou FireOS."

---

# Accessibilité

Le SDK Braze pour Android suit les [directives d’accessibilité pour Android][1].

## TalkBack du message in-app

Pour que le TalkBack ou la voix off d’Android ne puisse pas lire le contenu situé derrière un message in-app pendant l’affichage, activez la configuration SDK suivante :

{% tabs %}
{% tab braze.xml %}

```xml
<bool name="com_braze_device_in_app_message_accessibility_exclusive_mode_enabled">true</bool>
```

{% endtab %}
{% tab KOTLIN %}

```kotlin
val brazeConfigBuilder = BrazeConfig.Builder()
brazeConfigBuilder.setIsInAppMessageAccessibilityExclusiveModeEnabled(true)
Braze.configure(this, brazeConfigBuilder.build())
```

{% endtab %}
{% tab JAVA %}

```java
BrazeConfig.Builder brazeConfigBuilder = new BrazeConfig.Builder()
brazeConfigBuilder.setIsInAppMessageAccessibilityExclusiveModeEnabled(true);
Braze.configure(this, brazeConfigBuilder.build());
```

{% endtab %}
{% endtabs %}


[1]: https://developer.android.com/guide/topics/ui/accessibility
