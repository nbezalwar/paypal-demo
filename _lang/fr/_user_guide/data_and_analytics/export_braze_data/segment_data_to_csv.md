---
nav_title: Exporter les données du segment dans un CSV
article_title: Exporter les données du segment dans un CSV
page_order: 2
page_type: reference
description: "Cet article de référence explique comment exporter les données d’un segment dans un fichier CSV."

---

# Exportation vers CSV

Pour demander une exportation CSV des données utilisateur d’un segment, cliquez sur **Données utilisateur** lors de la modification d’un segment et sélectionnez d’exporter soit les données utilisateur, soit les adresses e-mail du segment.

![][1]

Vous pouvez également demander une exportation CSV depuis la page**Segments** principale en cliquant sur la liste déroulante<i class="fas fa-gear"></i> **Paramètres** d’un segment :

![][2]

Le fichier CSV contient les données de chaque profil utilisateur capturé dans le segment au moment de l’exportation. Vous pouvez exporter n’importe quel segment en cliquant sur l’icône d’engrenage puis Exportation CSV. Braze génère le rapport en arrière-plan et l’envoie par e-mail à l’utilisateur actuellement connecté.

{% alert important %} 
En raison des limites de taille de fichier, votre exportation peut échouer si la taille estimée de votre segment fait plus de 500 000 utilisateurs. Notez que cette restriction est basée sur la taille estimée de votre segment, et non sur la taille exacte. Si votre fichier est trop volumineux, envisagez d’utiliser des [ numéros de compartiment aléatoire]({{site.baseurl}}/user_guide/engagement_tools/campaigns/ideas_and_strategies/ab_testing_with_random_buckets/#step-1-segment-your-users-by-the-random-bucket-attribute) pour diviser votre base utilisateurs en plusieurs segments que vous regrouperez après l’exportation. Par exemple, si vous voulez diviser votre segment en 2, vous pouvez le faire avec les filtres suivants :

- Segment 1 : Le numéro de compartiment aléatoire est inférieur à 5 000 (inclut 0-4999)
- Segment 2 : Le numéro de compartiment aléatoire est supérieur à 4999 (inclut 5000-9999)

{% endalert %}

Si vous avez indiqué vos [informations d'identification S3 d’Amazon][26] dans Braze, le CSV sera alors chargé dans votre compartiment S3 sous la clé `segment-export/SEGMENT_ID/YYYY-MM-dd/users-RANDOMSTRING.zip`. Le lien envoyé par e-mail expirera après 1 jour d’exportation. Vous devez être connecté au tableau de bord pour pouvoir y accéder.

Données incluses dans les exportations :

- Toutes les données utilisateur
    - User ID
    - Prénom
    - Nom
    - Fuseau horaire
    - Ville
    - Sexe
    - Adresse e-mail
    - Numéro de téléphone
    - Nombre de jetons de notification push
    - Nom d’utilisateur Twitter
    - Nombre de sessions
    - Première session
    - Dernière session
    - Dernière version de l’application utilisée
    - Total d’achat in-App
    - Date de désinscription de l’e-mail 
    - Infos sur l’appareil
    - Nombre d’IDFAs
    - Nombre d’IDFVs
    - Événements personnalisés
    - Attributs personnalisés
- Adresses e-mail
    - User ID
    - Prénom
    - Nom
    - Adresse e-mail
    - Date de désinscription aux e-mails
    - Date d’abonnement e-mail

{% alert tip %}
Pour obtenir de l’aide sur les exportations de CSV et l’API, consultez notre article [Résolution des problèmes d’exportation]({{site.baseurl}}/user_guide/data_and_analytics/export_braze_data/export_troubleshooting/).
{% endalert %} 

[1]: {% image_buster /assets/img_archive/csvexport.png %}
[2]: {% image_buster /assets/img_archive/csvexport2.png %}
[26]: {{site.baseurl}}/partners/data_and_infrastructure_agility/data_warehouses/amazon_s3/#amazon-s3-integration
