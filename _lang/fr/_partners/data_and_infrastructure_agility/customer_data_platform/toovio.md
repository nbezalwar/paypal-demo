---
nav_title: Toovio
article_title: Toovio
page_order: 1
description: "Cet article présente le partenariat entre Braze et Toovio, une entreprise de DaaS (Data-as-a-Service) qui vous aide à découvrir vos données exploitables et à utiliser les éléments les plus importants pour générer progressivement des résultats en fonction d’objectifs prédéfinis."
alias: /partners/toovio/
page_type: partner
search_tag: Partenaire

---

# Toovio

> [Toovio](https://toovio.com/) est une entreprise de DaaS (Data-as-a-Service) qui s’appuie sur l’intelligence artificielle pour vous aider à découvrir vos données exploitables et à utiliser les éléments les plus critiques pour générer progressivement des résultats en fonction d’objectifs prédéfinis.

Le partenariat entre Braze et Toovio fournit des déclenchements de messages en temps quasi réel, des outils pour stimuler les performances et un accès aux outils avancés de mesure de campagne de Toovio.

## Conditions préalables

| Configuration requise | Description |
| ----------- | ----------- |
| Compte Toovio | Un compte Toovio est requis pour profiter de ce partenariat. |
| Clé API REST Braze | Une clé API REST Braze avec des autorisations `users.track`. <br>
<br>
 Cela peut être créé dans le **Tableau de bord de Braze > Developer Console > REST API Key (Clé API REST) > Create New Api Key** (Créer une nouvelle clé API). |
| Braze Currents | Braze Currents permet aux clients Braze d’envoyer des données d’événement ou de comportement à un partenaire de données de Braze (AWS S3, Google Cloud Storage ou Microsoft Azure Blob Storage) pour qu’elles soient traitées en dehors de la plateforme de Braze. |
{: .reset-td-br-1 .reset-td-br-2}

## Intégration

L’intégration suivante permet à Toovio de générer des déclencheurs ciblant des clients spécifiques et de communiquer en temps quasi réel. L’intégration de Toovio à Braze s’effectue de SDK à SDK. Les déclencheurs déterminés par Toovio seront transmis au Braze via l’endpoint d’API [users/track][3] de Braze.

### Étape 1 : Définir le partenaire de données

Un emplacement de dépôt pour le flux Currents doit être partagé avec Toovio ; cela permet à Toovio d’accéder aux données d’événement et de comportement des utilisateurs et de les traiter.

### Étape 2 : Configurer une campagne avec déclencheur

Créez une [campagne Braze déclenchée par API][4] sur la base des événements clients que Toovio ciblera. De plus, les attributs et valeurs de l’utilisateur cible qui déclencheront la campagne doivent être définis.

### Étape 3 : Configurer votre compte Toovio

Contactez Toovio à l’adresse [info@toovio.com](mailto:info@toovio.com?subject=New%20Customer%20Request) avec l’objet « Nouveau compte client » pour configurer un compte. Toovio travaillera avec les clients pour configurer des déclencheurs et des modèles sous-jacents.

[1]: https://www.braze.com/docs/user_guide/data_and_analytics/braze_currents/
[2]: https://www.braze.com/docs/api/api_key/
[3]: https://www.braze.com/docs/api/endpoints/user_data/post_user_track/
[4]: https://www.braze.com/docs/api/endpoints/messaging/send_messages/post_send_triggered_campaigns/
