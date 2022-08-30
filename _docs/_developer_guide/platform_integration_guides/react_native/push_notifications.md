---
nav_title: Push Notifications
article_title: Push Notifications for React Native
platform: React Native
page_order: 2
description: "This article covers implementing push notifications on React Native."
channel: push

---

# Push notifications

Integrating push notifications in React Native requires setting up each native platform separately. Follow the respective guides listed to finish the installation.

## Step 1: Complete native setup

{% tabs %}
{% tab Expo %}

Set the `enableBrazeIosPush` and `enableFirebaseCloudMessaging` props to enable push for iOS and Android, respectively.

### Android setup

#### Step 1.1
Set the `firebaseCloudMessagingSenderId` config prop in your `app.json`. See the [Android integration instructions]({{site.baseurl}}/developer_guide/platform_integration_guides/android/push_notifications/android/integration/standard_integration#step-4-set-your-firebase-credentials) on retrieving your sender ID. 

#### Step 1.2
Add your `google-services.json` file to your application's `assets` folder. This file is required when setting `enableFirebaseCloudMessaging: true` in your configuration.

```json
{
  "expo": {
    "plugins": [
      [
        "@braze/expo-plugin",
        {
          "androidApiKey": "YOUR-ANDROID-API-KEY",
          "iosApiKey": "YOUR-IOS-API-KEY",
          "enableBrazeIosPush": true,
          "enableFirebaseCloudMessaging": true,
          "firebaseCloudMessagingSenderId": "YOUR-FCM-SENDER-ID"
        }
      ],
    ]
  }
}
```

{% endtab %}
{% tab Android %}

Follow the [Android integration instructions]({{site.baseurl}}/developer_guide/platform_integration_guides/android/push_notifications/android/integration/standard_integration/).

{% endtab %}
{% tab iOS %}

Follow the [iOS integration instructions]({{site.baseurl}}/developer_guide/platform_integration_guides/ios/push_notifications/integration/). If you prefer not to request push permission upon launching the app, you should omit the `requestAuthorizationWithOptions:completionHandler:` call in your AppDelegate and follow the step below.

{% endtab %}
{% endtabs %}

## Step 2: Request push notifications permission

Use the `Braze.requestPushPermission()` method (available on v1.38.0 and up) to request permission for push notifications from the user on iOS and Android 13+. For Android 12 and below, this method is a no-op.

This method takes in a required parameter that specifies which permissions the SDK should request from the user on iOS. These options have no effect on Android.

```javascript
const permissionOptions = {
  alert: true,
  sound: true,
  badge: true,
  provisional: false
};

Braze.requestPushPermission(permissionOptions);
```

#### Step 2.1: Listen for push notifications on Android (optional)

```javascript
Braze.addListener(Braze.Events.PUSH_NOTIFICATION_EVENT, data => {
  console.log(`Push Notification event of type ${data.push_event_type} seen. Title ${data.title}\n and deeplink ${data.deeplink}`);
  console.log(JSON.stringify(data, undefined, 2));
});
```

## Step 3: Test displaying push notifications

At this point, you should be able to send notifications to the devices. Adhere to the following steps to test your push integration.

{% alert important %}
You can't test push notification related app behavior on an iOS simulator because simulators don't support the device tokens required to send and receive a push notification.
{% endalert %}

1. Set an active user in the React application by calling `Braze.changeUserId('your-user-id')` method.
2. Head to **Campaigns** and create a new push notification campaign. Choose the platforms that you'd like to test.
3. Compose your test notification and head over to the **Test** tab. Add the same `user-id` as the test user and click **Send Test**. You should receive the notification on your device shortly.

![A Braze push campaign showing you can add your own user ID as a test recipient to test your push notification.][1]

[1]: {% image_buster /assets/img/react-native/push-notification-test.png %} "Push Campaign Test"
