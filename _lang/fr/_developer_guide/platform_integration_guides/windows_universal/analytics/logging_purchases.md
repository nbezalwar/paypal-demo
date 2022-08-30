---
nav_title: Enregistrer les achats
article_title: Enregistrer les achats pour Windows Universal
platform: Windows Universal
page_order: 4
description: "Cet article de référence explique comment enregistrer les achats sur la plateforme Windows Universal."

---

# Enregistrer les achats
{% include archive/windows_deprecation.md %}

Enregistrez les achats dans l’application afin que vous puissiez suivre vos revenus au fil du temps et entre leurs différentes sources, tout en segmentant vos utilisateurs selon leur valeur à vie.

Braze prend en charge les achats dans plusieurs devises. Les achats que vous effectuez dans une devise autre qu’USD seront affichés dans le tableau de bord en USD en fonction du taux de change à la date à laquelle ils ont été enregistrés.

Avant l’implémentation, assurez-vous d’étudier des exemples d’options de segmentation offertes par les événements personnalisés, les attributs personnalisés et les événements d’achat dans notre article sur les [bonnes pratiques][3]. Nous vous recommandons également de vous familiariser avec nos [conventions de dénomination des événements]({{site.baseurl}}/user_guide/data_and_analytics/custom_data/event_naming_conventions/).

Pour utiliser cette fonction, ajoutez cet appel de méthode après un achat réussi dans votre application :

Tous les achats sont enregistrés en utilisant le `EventLogger`, qui est une propriété exposée dans IAppboy. Pour obtenir une référence au `EventLogger`, appelez `Appboy.SharedInstance.EventLogger`.

```csharp
bool LogPurchase(string productId, string currencyCode, decimal price)
```

## API REST

Vous pouvez également utiliser notre API REST pour enregistrer les achats. Reportez-vous à la documentation de l’[API utilisateur][2] pour plus de détails.

[2]: {{site.baseurl}}/developer_guide/rest_api/user_data/#user-data
[3]: {{site.baseurl}}/developer_guide/platform_wide/analytics_overview/#user-data-collection
