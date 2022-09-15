---
nav_title: "Types d’identifiant API"
article_title: Types d’identifiant API
page_order: 2.2
description: "Cet article de référence couvre les différents types d’identifiants API qui existent dans le tableau de bord Braze, où vous pouvez les trouver et à quoi ils servent." 
page_type: reference

---

# Types d’identifiant API

> Ce guide de référence aborde les différents types d’identifiants API qui se trouvent dans le tableau de bord Braze, leur objectif, où vous pouvez les trouver et comment ils sont généralement utilisés. Pour plus d’informations sur les clés API REST ou les clés API du groupe d’applications, reportez-vous à la présentation des clés API [Rest]({{site.baseurl}}/api/api_key/)

Les identifiants API suivants peuvent être utilisés pour accéder à votre modèle, toile, campagne, segment, envoi ou carte à partir de l’API externe de Braze. Tous les messages doivent suivre le codage [UTF-8][1].

{% tabs %}
{% tab App Ids %}

## La clé API App Identifier

La clé API App Identifier ou `app_id` est un paramètre associant une activité à une application spécifique dans votre groupe d’applications. Il désigne l’application du groupe d’applications avec lequel vous interagissez. Par exemple, vous verrez que vous aurez un `app_id` pour votre application iOS, un `app_id` pour votre application Android et un `app_id` pour votre intégration Web. Chez Braze, vous pourriez trouver que vous avez plusieurs applications pour la même plateforme sur les différents types de plateforme pris en charge par Braze.

#### Où puis-je le trouver ?

Il existe deux façons de localiser votre `app_id` :

1. Vous pouvez trouver cet identifiant `app_id` ou l’identifiant de l’application dans la console **** Developer sous **Paramètres**. Sur cette nouvelle page, sous **Identification**, vous pourrez voir toutes les `app_id` qui existent pour vos applications.

2. Allez dans **Gérer les paramètres** sous **Paramètres**. À partir de cette nouvelle page, dans l’onglet **Paramètres**, à mi-chemin de la page, vous trouverez une « clé API pour NOM** DE L’**APPLICATION sur **la PLATEFORME**» (par ex. « Clé API pour la crème glacée sur iOS). Cette clé API est votre identifiant d’application.

#### À quoi peut-il servir ?

Les identifiants d’application chez Braze sont utilisés lors de l’intégration du SDK et sont également utilisés pour référencer une application spécifique dans les appels d’API REST. Avec le , `app_id` vous pouvez faire de nombreuses choses comme extraire des données pour un événement personnalisé qui s’est produit pour une application particulière, récupérer des statistiques de désinstallation, des statistiques de nouvel utilisateur, des statistiques DAU et des statistiques de démarrage de session pour une application particulière.

Parfois, vous pouvez trouver que vous êtes invité à créer un `app_id` mais que vous ne travaillez pas avec une application, car il s’agit d’un champ hérité spécifique à une plateforme spécifique, vous pouvez « omettre » ce champ en incluant n’importe quelle chaîne de caractères comme espace réservé pour ce paramètre requis.

#### Plusieurs clés API d’identifiant d’application

Lors de la configuration du SDK, le cas d’utilisation le plus courant pour plusieurs clés API App Identifier est la séparation de ces clés pour les variantes de débogage et de version.
Pour basculer facilement entre plusieurs clés API App Identifier dans vos builds, nous vous recommandons de créer un `braze.xml` fichier distinct pour chaque variantede [build pertinente][3]. Une variante de construction est une combinaison de type de construction et de saveur de produit. Notez que par défaut, un nouveau projet Android est configuré avec `debug` des types de `release` build et sans arômes de produit.

Pour chaque variante de construction pertinente, créez-`braze.xml`en une nouvelle dans `src/<build variant name>/res/values/` :

```xml
<?xml version="1.0" encoding="utf-8"?>
<resources>
<string name="com_braze_api_key">REPLACE_WITH_YOUR_BUILD_VARIANT_API_KEY</string>
</resources>
```
Lorsque la variante de création est compilée, elle utilise la nouvelle clé API.

{% endtab %}
{% tab Template Ids %}

## Identifiant API du modèle

Un identifiant API de [modèle]({{site.baseurl}}/api/endpoints/templates/) ou ID de modèle est une clé prête à l’emploi par Braze pour un modèle donné dans le tableau de bord. Les ID de modèle sont uniques pour chaque modèle et peuvent être utilisés pour référencer des modèles via l’API. 

Les modèles sont parfaits si votre entreprise sous-traite vos conceptions HTML pour les campagnes. Une fois les modèles créés, vous disposez désormais d’un modèle qui n’est pas spécifique à une campagne, mais qui peut être appliqué à une série de campagnes comme une newsletter.

#### Où puis-je le trouver ?
Vous pouvez trouver votre ID de modèle de deux façons :

1. Dans le tableau de bord, ouvrez **Modèles et médias** sous **Engagement** et sélectionnez un modèle préexistant. Si le modèle que vous souhaitez n’existe pas encore, créez-en un et enregistrez-le. En bas de la page du modèle individuel, vous pourrez trouver votre identifiant API de modèle.<br>
<br>

2. Braze propose une recherche d’identifiants** API **supplémentaires, ici vous pouvez rapidement rechercher des identifiants spécifiques. Il se trouve en bas de l’onglet Paramètres **** API dans la page Console** du **développeur.

#### À quoi peut-il servir ?

- Mettre à jour les modèles sur l’API
- Obtenir des informations sur un modèle spécifique

<br>
{% endtab %}
{% tab Canvas IDs %}

## Identifiant API Canvas

Un identifiant d’API [Canvas]({{site.baseurl}}/user_guide/engagement_tools/canvas/) ou un identifiant Canvas est une clé prête à l’emploi de Braze pour une toile donnée dans le tableau de bord. Les identifiants Canvas sont uniques à chaque Canvas et peuvent être utilisés pour référencer les Canvas via l’API. 

Notez que si vous avez un Canvas qui a des variantes, il existe un ID de Canvas global ainsi que des ID de Canvas individuels imbriqués sous le Canvas principal. 

#### Où puis-je le trouver ?
Vous pouvez trouver votre identifiant Canvas dans le tableau de bord. Ouvrez **Canvas** sous **Engagement** et sélectionnez une toile préexistante. Si la toile que vous souhaitez n’existe pas encore, créez-en une et enregistrez-la. Au bas d’une page Canvas individuelle, cliquez sur **Analyser les variantes**. Une fenêtre apparaît avec l’identifiant de l’API Canvas situé en bas.

#### À quoi peut-il servir ?
- Suivre les analyses sur un message spécifique
- Obtenez des statistiques agrégées de haut niveau sur les performances de Canvas
- Saisir des détails sur une toile spécifique
- Avec Currents pour apporter des données au niveau de l’utilisateur pour une approche « plus globale » des toiles
- Avec livraison de déclencheur API afin de collecter des statistiques pour les messages transactionnels

<br>
{% endtab %}
{% tab Campaign IDs %}

## Identifiant API de campagne

Un identifiant API [de campagne]({{site.baseurl}}/user_guide/engagement_tools/campaigns/) ou ID de campagne est une clé prête à l’emploi par Braze pour une campagne donnée dans le tableau de bord. Les ID de campagne sont uniques à chaque campagne et peuvent être utilisés pour référencer des campagnes via l’API. 

Notez que si vous avez une campagne qui a des variantes, il y a à la fois un ID de campagne global ainsi que des ID de campagne de variante individuels imbriqués sous la campagne principale. 

#### Où puis-je le trouver ?
Vous pouvez trouver votre ID de campagne de deux façons :

1. Dans le tableau de bord, ouvrez **Campagnes** sous **Engagement** et sélectionnez une campagne préexistante. Si la campagne que vous souhaitez n’existe pas encore, créez-en une et enregistrez-la. En bas de la page de campagne individuelle, vous pourrez trouver votre identifiant API de **campagne**.<br>
<br>

2. Braze propose une recherche d’identifiants** API **supplémentaires, ici vous pouvez rapidement rechercher des identifiants spécifiques. Vous pouvez le trouver en bas de l’onglet Paramètres **** API dans la console du **développeur**.

#### À quoi peut-il servir ?
- Suivre les analyses sur un message spécifique
- Obtenir des statistiques agrégées de haut niveau sur les performances de la campagne
- Obtenir des détails sur une campagne spécifique
- Avec Currents pour apporter des données au niveau de l’utilisateur pour une approche « plus globale » des campagnes
- Avec livraison déclenchée par API afin de collecter des statistiques pour les messages transactionnels
- Pour [rechercher une campagne]({{site.baseurl}}/user_guide/engagement_tools/campaigns/managing_campaigns/search_campaigns/#search-syntax) spécifique sur la page **Campagnes** à l’aide du filtre `api_id:YOUR_API_ID`

<br>
{% endtab %}
{% tab Segment IDs %}

## Identifiant API du segment

Un identifiant API de [segment]({{site.baseurl}}/user_guide/engagement_tools/segments/) ou ID de segment est une clé prête à l’emploi par Braze pour un segment donné dans le tableau de bord. Les ID de segment sont uniques à chaque segment et peuvent être utilisés pour référencer des segments via l’API. 

#### Où puis-je le trouver ?
Vous pouvez trouver votre ID de segment de deux manières :

1. Dans le tableau de bord, ouvrez **Segments** sous **Engagement** et sélectionnez un segment préexistant. Si le segment que vous souhaitez n’existe pas encore, créez-en un et enregistrez-le. En bas de la page de segment individuel, vous pourrez trouver votre identifiant API de segment. <br>
<br>

2. Braze propose une recherche d’identifiants** API **supplémentaires, ici vous pouvez rapidement rechercher des identifiants spécifiques. Il se trouve en bas de l’onglet Paramètres **** API dans la page Console** du **développeur.

#### À quoi peut-il servir ?
- Obtenir des détails sur un segment spécifique
- Récupérer l’analyse d’un segment spécifique
- Indiquez combien de fois un événement personnalisé a été enregistré pour un segment particulier
- Spécifier et envoyer une campagne à un membre d’un segment à partir de l’API

{% endtab %}
{% tab Card IDs %}

## Identifiant API de la carte

Un identifiant d’API de carte ou ID de carte est une clé prête à l’emploi par Braze pour une carte de fil d’actualité donnée dans le tableau de bord. Les ID de carte sont uniques à chaque carte de fil d[’]({{site.baseurl}}/user_guide/engagement_tools/news_feed/)actualité et peuvent être utilisés pour référencer les cartes via l’API. 

#### Où puis-je le trouver ?
Vous pouvez trouver votre ID de carte de l’une des deux manières suivantes :

1. Dans le tableau de bord, ouvrez le fil d**’**actualité sous **Engagement** et sélectionnez un fil d’actualité préexistant. Si le fil d’actualité que vous souhaitez n’existe pas encore, créez-en un et enregistrez-le. En bas de la page du fil d’actualités individuel, vous pourrez trouver votre identifiant API de carte unique. <br>
<br>

2. Braze propose une recherche d’identifiants** API **supplémentaires, ici vous pouvez rapidement rechercher des identifiants spécifiques. Il se trouve en bas de l’onglet Paramètres **** API dans la page Console** du **développeur.

#### À quoi peut-il servir ?
- Récupérer les informations pertinentes sur une carte
- Suivre les événements liés aux cartes de contenu et à l’engagement

<br>
{% endtab %}
{% tab Send IDs %}

## Envoyer l’identifiant

Un identifiant d’envoi ou ID d’envoi est une clé générée par Braze ou créée par vous pour un message donné envoyé sous lequel les analyses doivent être suivies. L’identifiant d’envoi vous permet de récupérer les analyses pour une instance spécifique d’un envoi de campagne via le [`sends/data_series`]({{site.baseurl}}/api/endpoints/export/campaigns/get_send_analytics/) point de terminaison.

#### Où puis-je le trouver ?

L’API et les campagnes de déclenchement d’API envoyées en tant que diffusion généreront automatiquement un identifiant d’envoi si aucun identifiant d’envoi n’est fourni. Si vous souhaitez spécifier votre propre identifiant d’envoi, vous devrez d’abord en créer un via le [`sends/id/create`]({{site.baseurl}}/api/endpoints/messaging/send_messages/post_create_send_ids/) endpoint. L’identifiant doit comporter tous les caractères ASCII et ne pas dépasser 64 caractères. Vous pouvez réutiliser un identifiant d’envoi pour plusieurs envois d’une même campagne si vous souhaitez regrouper les analyses de ces envois.

#### À quoi peut-il servir ?
Envoyez et suivez les performances des messages par programme, sans création de campagne pour chaque envoi.

<br>
{% endtab %}
{% endtabs %}

[1]: https://en.wikipedia.org/wiki/UTF-8
[3]: https://developer.android.com/studio/build/build-variants.html
