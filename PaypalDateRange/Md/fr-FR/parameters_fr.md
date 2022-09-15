---
page_order: 2.4
nav_title: Paramètres
article_title: Paramètres API
layout: glossary_page
glossary_top_header: "Paramètres"
glossary_top_text: "Utilisez ces paramètres pour définir vos demandes API. Bien que les paramètres dont vous avez besoin soient répertoriés sous les critères d’évaluation, cela devrait vous donner plus d’informations sur leur nuance et d’autres spécifications."

description: "Ce glossaire couvre en détail les paramètres impliqués dans les demandes d’API." 
page_type: glossary

glossaries:
  - name: Clé API REST du groupe d’applications
    description: Le <code>api_key</code> indique le titre de l’application auquel les données de cette demande sont associées et authentifie le demandeur en tant que personne autorisée à envoyer des messages à l’application. Il doit être inclus dans chaque demande en tant qu’en-tête d’autorisation HTTP. Il se trouve dans la section Console<strong> du </strong>développeur du tableau de bord Braze.
    field: "api_key"
  - name: Identifiant de l’application
    description: Si vous souhaitez envoyer des messages push à un ensemble de jetons d’appareil (au lieu d’utilisateurs), vous devez indiquer au nom de quelle application spécifique vous envoyez des messages. Dans ce cas, vous fournirez l’identifiant d’application approprié dans un objet jetons. Il se trouve dans la section Console<strong> du </strong>développeur du tableau de bord Braze.
    field: "app_id"
  - name: ID utilisateur externe
    description: Un identifiant unique pour envoyer un message à des utilisateurs spécifiques. Cet identifiant doit être identique à celui que vous avez défini dans le SDK Braze. Vous ne pouvez cibler que les utilisateurs pour la messagerie qui ont déjà été identifiés via le SDK ou l’API utilisateur. Un maximum de 50 ID utilisateur externes est autorisé dans une demande. <br>
 <br>
 Pour les points de terminaison de déclencheur de campagne, si vous fournissez ce champ, les critères seront superposés avec les segments de campagne et seuls les utilisateurs qui figurent dans la liste des ID d’utilisateur externes et le segment de campagne recevront le message.
    field: "external_user_ids"
  - name: Identifiant de segment
    description: Le <code>segment_id</code> indique le segment auquel le message doit être envoyé. Un identifiant de segment pour chacun des segments que vous avez créés se trouve dans la section Console<strong> du </strong>développeur du tableau de bord Braze. <br>
 <br>
 Pour les points de terminaison de message, si vous fournissez à la fois un identifiant de segment et une liste d’identifiants d’utilisateur externes dans une seule demande de messagerie, les critères seront superposés et seuls les utilisateurs qui figurent dans la liste d’identifiants d’utilisateur externes et le segment fourni recevront le message.
    field: "segment_id"
  - name: Identifiant de campagne
    description: Pour les points de terminaison de messagerie, le <code>campaign_id</code> indique la campagne API sous laquelle l’analyse d’un message doit être suivie. Vous trouverez un identifiant de campagne pour chacune des campagnes que vous avez créées dans la section Console<strong> du </strong>développeur du tableau de bord Braze. Si vous fournissez un identifiant de campagne dans le corps de la demande, vous devez fournir un <code>message_variation_id</code> dans chacun des objets de message indiquant la variante représentée de votre campagne. <br>
 <br>
 Pour les points de terminaison de déclenchement de campagne, le <code>campaign_id</code> indique l’ID API de la campagne à déclencher. Ce champ est requis pour toutes les demandes de point de terminaison de déclenchement.
    field: "campaign_id"
  - name: Identifiant en toile
    description: Pour les endpoints déclenchant Canvas, le <code>canvas_id</code> indique l’identifiant du Canvas à déclencher ou à planifier. Ce champ est requis pour toutes les demandes de point de terminaison de déclenchement.
    field: "canvas_id"
  - name: Envoyer l’identifiant
    description: Pour les terminaux de messagerie, <code>send_id</code> indique l’envoi sous lequel l’analyse d’un message doit être suivie. Le vous <code>send_id</code> permet d’extraire des analyses pour une instance spécifique d’une campagne envoyée via le <code>sends/data_series</code> point de terminaison. L’API et les campagnes de déclenchement d’API envoyées en tant que diffusion généreront automatiquement un identifiant d’envoi si aucun identifiant d’envoi n’est fourni. <br>
 <br>
 Si vous souhaitez spécifier votre propre <code>send_id</code>, vous devez d’abord en créer un via le <code>sends/id/create</code> endpoint. Le <code>send_id</code> doit contenir tous les caractères ASCII et ne pas dépasser 64 caractères.  Vous pouvez réutiliser un identifiant d’envoi pour plusieurs envois d’une même campagne si vous souhaitez regrouper les analyses de ces envois. <br>
 <br>
 Notez que le <code>send_id</code> suivi n’est pas disponible pour les e-mails envoyés via Mailjet. <br>
 <br>
 Les conversions de campagne sont attribuées au dernier suivi <code>send_id</code> que l’utilisateur a reçu de cette campagne, sauf si le dernier envoi que l’utilisateur a reçu n’a pas été suivi.
    field: "send_id"
  - name: Propriétés du déclencheur
    description: "Lorsque vous utilisez l’un des endpoints pour envoyer une campagne avec une livraison déclenchée par API, vous pouvez fournir une carte des clés et des valeurs pour personnaliser votre message. Si vous effectuez une demande API contenant un objet dans <code>\"trigger_properties\"</code>, les valeurs de cet objet peuvent alors être référencées dans votre modèle de message sous le <code>api_trigger_properties</code> namespace. <br>
 <br>
 Par exemple, une demande avec <code>\"trigger_properties\" : {\"product_name\" : \"shoes\", \"product_price\" : 79.99}</code> peut ajouter le mot \"chaussures\" au message en ajoutant <code>{{api_trigger_properties.${product_name}}}</code>."
    field: "trigger_properties"
  - name: Propriétés d’entrée en toile
    description: "Lorsque vous utilisez l’un des critères d’évaluation pour déclencher ou planifier un Canvas via l’API, vous pouvez fournir une carte des clés et des valeurs pour personnaliser les messages envoyés par les premières étapes de votre Canvas, dans l’espace de <code>\"canvas_entry_properties\"</code> noms. <br>
 <br>
 Par exemple, une demande avec <code>\"canvas_entry_properties\" : {\"product_name\" : \"shoes\", \"product_price\" : 79.99}</code> peut ajouter le mot \"chaussures\" à un message en ajoutant <code>{{canvas_entry_properties.${product_name}}}</code>."
    field: "canvas_entry_properties"
  - name: Diffusion
    description: "Lors de l’envoi d’un message à un segment ou à une audience de campagne à l’aide d’un point de terminaison API, Braze vous demande de définir explicitement si votre message est une \"diffusion\" à un grand groupe d’utilisateurs en incluant un <code>broadcast</code> booléen dans l’appel API. Autrement dit, si vous avez l’intention d’envoyer un message API à l’ensemble du segment ciblé par une campagne ou Canvas, vous devez l’inclure <code>broadcast: true</code> dans votre appel API. <br>
<br>
La diffusion est un champ obligatoire et la valeur par défaut définie par Braze lorsqu’une campagne ou Canvas est effectuée est <code>broadcast: false</code>. Vous ne pouvez pas avoir les deux <code>broadcast: true</code> et une <code>recipients</code> liste spécifiée. Si l’<code>broadcast</code>indicateur est défini sur vrai et qu’une liste explicite de destinataires est fournie, le point de terminaison API renverra une erreur. De même, inclure <code>broadcast: false</code> et ne pas fournir une liste de destinataires renvoie une erreur. 
    
    <br>
<br>
Soyez prudent lorsque vous définissez <code>broadcast: true</code>, car le fait de définir involontairement cet indicateur peut vous amener à envoyer votre campagne ou Canvas à un public plus grand que prévu. L’<code>broadcast</code>indicateur est nécessaire pour se protéger contre les envois accidentels à de grands groupes d’utilisateurs."
    field: "broadcast"
    
---
