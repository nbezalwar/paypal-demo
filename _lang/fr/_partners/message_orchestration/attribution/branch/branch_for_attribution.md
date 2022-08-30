---
nav_title: Branch pour l’attribution
article_title: Branch pour l’attribution
alias: /partners/branch_for_attribution/
description: "Cet article décrit le partenariat entre Braze et Branch, une plateforme de liaison mobile qui vous aide à acquérir, engager et mesurer sur tous les appareils, canaux et plateformes."
page_type: partner
search_tag: Partenaire

---

# Branch pour l’attribution {#branch}

{% include video.html id="PwGKqfwV-Ss" align="right" %}

> [Branch](https://docs.branch.io/pages/integrations/braze/) est une plateforme de liaison mobile qui vous aide à acquérir, engager et mesurer à travers tous les appareils, canaux et plateformes en vous offrant une vue complète de tous les points de contact avec les utilisateurs.

L’intégration de Braze et de Branch vous aidera à comprendre exactement quand et où les utilisateurs ont été acquis, ainsi qu’à personnaliser leur parcours grâce à une attribution robuste et à des [liens profonds]({{site.baseurl}}/partners/channel_extensions/deep_linking/branch_for_deeplinking/).

## Conditions préalables

| Configuration requise | Description |
|---|---|
| Compte Branch | Un compte Branch est requis pour profiter de ce partenariat. |
| Application iOS ou Android | Cette intégration prend en charge les applications iOS et Android. Selon votre plateforme, les extraits de code peuvent être requis dans votre application. Vous trouverez des détails sur ces exigences à l’étape 1 du processus d’intégration. |
| SDK Branch | En plus du SDK Braze requis, vous devez installer le [SDK Branch](https://help.branch.io/developers-hub/docs/native-sdks-overview). |
{: .reset-td-br-1 .reset-td-br-2}

## Intégration

### Étape 1 : Mapper les ID de périphérique

#### Android 

Si vous avez une application Android, vous devez transmettre un ID de périphérique Braze unique à Branch. Cet ID peut être défini dans le SDK Branch de la méthode `setRequestMetadataKey()`. L’extrait de code suivant doit être inclus avant d’appeler `initSession`. Vous devez également initialiser le SDK Braze avant de définir les métadonnées de demande dans le SDK Branch.

```java
Branch.getInstance().setRequestMetadata("$braze_install_id", Braze.getInstance(context).getInstallTrackingId());

...

Branch.initSession(...);
```
#### iOS

Si vous disposez d’une application iOS, votre IDFV sera collecté par Branch et transmis à Braze. Cet ID sera ensuite mappé à un ID de périphérique unique dans Braze.

Braze conservera toujours les valeurs IDFA pour les utilisateurs qui ont choisi de collecter l’IDFA avec Braze, comme décrit dans notre [Guide de mise à niveau vers iOS 14]({{site.baseurl}}/developer_guide/platform_integration_guides/ios/ios_14/#idfa). Sinon, l’IDFV sera utilisé comme identifiant de secours pour mapper les utilisateurs.

### Étape 2 : Obtenir la clé d’importation des données Braze

Dans Braze, accédez à **Technology Partners** et sélectionnez **Branch**. Ici, vous trouverez l’endpoint REST pour générer votre clé d’importation des données Braze. Une fois la clé générée, vous pouvez créer une nouvelle clé ou invalider une clé existante. La clé d’importation des données et l’endpoint REST sont utilisés dans l’étape suivante lors de la configuration d’un postback dans le tableau de bord de Branch.<br>
<br>
![Cette image affiche la zone « Data Import for Install Attribution » (Importation de données pour l’attribution d’installation) située sur la page Branch Technology. Dans cette zone, vous trouverez la clé d’importation des données et l’endpoint REST.][4]{: style="max-width:90%;"}

### Étape 3 : Configurer les flux de données

1. Dans Branch, sous la section **Exports** (Exportations), cliquez sur **Data Feeds**.
2. Sur la page **Data Feeds Manager**, cliquez sur l’onglet **Data Integrations** (Intégrations de données) en haut de la page. 
3. Sélectionnez Braze dans la liste des partenaires de données disponibles. 
4. Sur la page d’exportation de Braze, fournissez la clé d’importation des données et l’endpoint REST que vous avez trouvés dans le tableau de bord de Braze et cliquez sur **Enable** (Activer).

### Étape 4 : Confirmer l’intégration

Lorsque Braze reçoit les données d’attribution de Branch, l’indicateur de l’état de connexion sur la page des partenaires de technologie de Branch dans Braze passe de « Not connected » (Non connecté) à « Connected » (Connecté). Un horodatage de la dernière demande réussie sera également inclus. 

Notez que cela ne se produira pas tant que nous ne recevrons pas de données sur une installation attribuée. Les installations organiques, qui doivent être exclues du postback de Branch, sont ignorées par notre API et ne sont pas comptées lors de la détermination si une connexion réussie a été établie.

## Données d’attribution Facebook et Twitter

Les données d’attribution pour les campagnes Facebook et Twitter ne sont pas disponibles par l’intermédiaire de nos partenaires. Ces sources de médias ne permettent pas à leurs partenaires de partager des données d’attribution avec des tiers et, par conséquent, nos partenaires ne peuvent pas envoyer ces données à Braze.

## URL de suivi des clics de Branch dans Braze (facultatif)

L’utilisation des liens de suivi de vos campagnes Braze vous permettra de voir facilement quelles campagnes stimulent les installations des applications et le réengagement. Par conséquent, vous serez en mesure de mesurer vos efforts marketing plus efficacement et de prendre des décisions axées sur les données pour investir davantage de ressources selon le retour sur investissement (ROI) maximal.

Pour commencer avec les liens de suivi des clics de Branch, consultez la [documentation](https://help.branch.io/using-branch/docs/ad-links). Vous pouvez insérer directement les liens de suivi des clics de Branch dans vos campagnes Braze. Branch utilisera ensuite ses [méthodologies d’attribution probabilistes](https://help.branch.io/using-branch/docs/branch-attribution-logic-settings) pour attribuer l’utilisateur qui a cliqué sur le lien. Nous vous recommandons d’associer vos liens de suivi de Branch à un identifiant de périphérique pour améliorer la précision des attributions de vos campagnes Braze. L’utilisateur ayant cliqué sur le lien sera attribué de manière déterministe.

{% tabs %}
{% tab Android %}
Pour Android, Braze permet aux clients de s’abonner à la [collection d’ID publicitaires Google (GAID)]({{site.baseurl}}/developer_guide/platform_integration_guides/android/initial_sdk_setup/optional_gaid_collection/#optional-google-advertising-id). Le GAID est également collecté de manière native par l’intégration du SDK Branch. Vous pouvez inclure le GAID dans vos liens Branch de suivi de clics en utilisant la logique Liquid suivante :
{% raw %}
```
{% if most_recently_used_device.${platform} == 'android' %}
user_data_aaid={{most_recently_used_device.${google_ad_id}}}
{% endif %}
```
{% endraw %}
{% endtab %}

{% tab iOS %}
Pour iOS, Braze et Branch collectent automatiquement l’IDFV par l’intermédiaire de nos intégrations SDK. Cela peut être utilisé comme identifiant de périphérique. Vous pouvez inclure l’IDFV dans vos liens Branch de suivi de clics en utilisant la logique Liquid suivante :

{% raw %}
```
{% if most_recently_used_device.${platform} == 'ios' %}
user_data_idfv={{most_recently_used_device.${id}}}
{% endif %}
```
{% endraw %}
{% endtab %}
{% endtabs %}

{% alert note %}
**Cette recommandation est purement facultative**<br>

Si vous n’utilisez actuellement aucun identifiant de périphérique, comme IDFV ou GAID, dans vos liens de suivi de clic, ou si vous ne le prévoyez pas à l’avenir, Branch pourra toujours attribuer ces clics via ses modélisations probabilistes.
{% endalert %}

[22]: https://docs.branch.io/pages/exports/ua-webhooks/ "Branch Webhooks"
[4]: {% image_buster /assets/img/attribution/branch.png %}
