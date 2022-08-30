---
nav_title: Fil d’actualité
article_title: Fil d’actualité pour Xamarin
platform: 
  - Xamarin
  - iOS
  - Android
page_order: 3
description: "Cet article couvre l’intégration de fils d’actualité sur iOS, Android et FireOS pour la plate-forme Xamarin."
channel: fil d’actualité 
---

# Fil d’actualité

## Android

Consultez les [instructions d’intégration Android][1] pour une savoir comment intégrer le fil d’actualité dans votre application Xamarin sur Android.  En outre, vous pouvez consulter [l’exemple d’application][2] pour des échantillons d’implémentation.

## iOS 

Consultez les [instructions d’intégration iOS][11] pour savoir comment intégrer le fil d’actualité dans votre application Xamarin sur iOS.  En outre, vous pouvez consulter [l’exemple d’application][12] pour des échantillons d’implémentation.

Parmi toutes les options d’implémentation, le plus rapide à mettre en œuvre est le Modal, qui peut être ajouté en procédant comme suit dans votre ViewController :

```csharp
// C#
ABKFeedViewControllerModalContext m = new ABKFeedViewControllerModalContext ();
this.PresentViewController (m, true, null);
```

[1]: {{site.baseurl}}/developer_guide/platform_integration_guides/android/news_feed/#news-feed
[2]: https://github.com/Appboy/appboy-xamarin-bindings
[11]: {{site.baseurl}}/developer_guide/platform_integration_guides/ios/news_feed/
[12]: https://github.com/Appboy/appboy-xamarin-bindings/tree/master/appboy-component/samples
