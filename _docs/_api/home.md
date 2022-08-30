---
page_order: 0
nav_title: Home
article_title: Braze API Guide
layout: api_glossary
glossary_top_header: "Braze API Guide"
glossary_top_text: "Braze provides a high-performance REST API to allow you to track users, send messages, export data, and more. This page lists available Braze API endpoints and their uses."
page_type: glossary
description: "This landing page lists available Braze API endpoints and their uses."
glossary_tag_name: Endpoint Type

glossary_filter_text: "Select endpoint type to narrow the glossary:"

glossary_mid_text: "<h2>Braze Endpoint Search</h2>"
guide_featured_list:
- name: Endpoints
  fa_icon: fa-solid fa-laptop-code
  link: /docs/api/endpoints/
- name: Objects & Filters
  link: /docs/api/objects_filters/
  fa_icon: fa-solid fa-gear
- name: API Overview
  fa_icon: fa-solid fa-info
  link: /docs/api/basics/
- name: API Identifier Types
  link: /docs/api/identifier_types/
  fa_icon: fa-solid fa-clipboard-list
- name: Errors & Responses
  link: /docs/api/errors/
  fa_icon: fa-solid fa-list-check
- name: Rate Limits
  link: /docs/api/api_limits/
  fa_icon: fa-solid fa-hand

# channel to icon/fa or image mapping
glossary_tags:
  - name: Campaign
  - name: Canvas
  - name: Content Blocks
  - name: Custom Events
  - name: Email List
  - name: Email Templates
  - name: KPI
  - name: News Feed
  - name: Purchases
  - name: Schedule Messages
  - name: Segments
  - name: Send Messages
  - name: SMS
  - name: Subscription Groups
  - name: User Data

glossaries:
  - name: <a href='/docs/api/endpoints/user_data/post_user_alias/'>/users/alias/new</a>
    description: Add new user aliases for existing identified users, or to create new unidentified users.
    tags:
      - User Data
  - name: <a href='/docs/api/endpoints/user_data/post_user_delete/'>/users/delete</a>
    description: Delete any user profile by specifying a known user identifier.
    tags:
      - User Data
  - name: <a href='/docs/api/endpoints/export/user_data/post_users_global_control_group/'>/users/export/global_control_group</a>
    description: Export all users within a Global Control Group.
    tags:
      - User Data
  - name: <a href='/docs/api/endpoints/export/user_data/post_users_identifier/'>/users/export/ids</a>
    description: Export data from any user profile by specifying a user identifier.
    tags:
      - User Data
  - name: <a href='/docs/api/endpoints/export/user_data/post_users_segment/'>/users/export/segment</a>
    description: Export all the users within a segment.
    tags:
      - User Data
  - name: <a href='/docs/api/endpoints/user_data/external_id_migration/post_external_ids_rename/'>/users/external_ids/rename</a>
    description: Rename your users’ external IDs.
    tags:
      - User Data
  - name: <a href='/docs/api/endpoints/user_data/external_id_migration/post_external_ids_remove/'>/users/external_ids/remove</a>
    description: Remove your users’ old deprecated external IDs.
    tags:
      - User Data
  - name: <a href='/docs/api/endpoints/user_data/post_user_identify/'>/users/identify</a>
    description: Identify an unidentified (alias-only) user.
    tags:
      - User Data
  - name: <a href='/docs/api/endpoints/user_data/post_user_track/'>/users/track</a>
    description: Record custom events, purchases, and update user profile attributes.
    tags:
      - User Data
  - name: <a href='/docs/api/endpoints/messaging/send_messages/post_send_triggered_campaigns/'>/campaigns/trigger/send</a>
    description: Send immediate, ad-hoc messages to designated users via API-triggered delivery.
      - Send Messages
  - name: <a href='/docs/api/endpoints/messaging/send_messages/post_send_triggered_canvases/'>/canvas/trigger/send</a>
    description: Send Canvas messages via API-Triggered delivery.
      - Send Messages
  - name: <a href='/docs/api/endpoints/messaging/send_messages/post_send_messages/'>/messages/send</a>
    description: Send immediate, ad-hoc messages to designated users via the Braze API.
    tags:
      - Send Messages
  - name: <a href='/docs/api/endpoints/messaging/send_messages/post_create_send_ids/'>/sends/id/create</a>
    description: Create send IDs that can be used to send messages and track message performance programatically, without campaign creation for each send.
    tags:
      - Send Messages
  - name: <a href='/docs/api/endpoints/messaging/send_messages/post_send_transactional_message/'>/transactional/v1/campaigns/{{CAMPAIGN_ID}}/send</a>
    description: Send immediate, ad-hoc transactional messages to a designated user.
    tags:
      - Send Messages
  - name: <a href='/docs/api/endpoints/messaging/schedule_messages/post_schedule_triggered_campaigns/'>/campaigns/trigger/schedule/create</a>
    description: Send dashboard created campaign messages (up to 90 days in advance) via API-triggered delivery.
    tags:
      - Schedule Messages 
  - name: <a href='/docs/api/endpoints/messaging/schedule_messages/post_delete_scheduled_triggered_messages/'>/campaigns/trigger/schedule/delete</a>
    description: Cancel API-triggered campaign messages that you previously scheduled before it has been sent.
    tags:
      - Schedule Messages
  - name: <a href='/docs/api/endpoints/messaging/schedule_messages/post_update_scheduled_triggered_campaigns/'>/campaigns/trigger/schedule/update</a>
    description: Update scheduled API-triggered campaigns created in the dashboard.
    tags:
      - Schedule Messages
  - name: <a href='/docs/api/endpoints/messaging/schedule_messages/post_delete_scheduled_triggered_canvases/'>/canvas/trigger/schedule/delete</a>
    description: Cancel a Canvas message that you previously scheduled via API-triggered before it has been sent.
    tags:
      - Schedule Messages 
  - name: <a href='/docs/api/endpoints/messaging/schedule_messages/post_schedule_triggered_canvases/'>/canvas/trigger/schedule/create</a>
    description: Schedule Canvas messages (up to 90 days in advance) via API-triggered delivery.
    tags:
      - Schedule Messages   
  - name: <a href='/docs/api/endpoints/messaging/schedule_messages/post_update_scheduled_messages/'>/messages/schedule/update</a>
    description: Update scheduled messages. This endpoint accepts updates to either the <code>schedule</code> or <code>messages</code> parameter or both.
    tags:
      - Schedule Messages      
  - name: <a href='/docs/api/endpoints/messaging/schedule_messages/post_delete_scheduled_messages/'>/messages/schedule/delete</a>
    description: Cancel a message that you previously scheduled before it has been sent.
    tags:
      - Schedule Messages 
  - name: <a href='/docs/api/endpoints/messaging/schedule_messages/post_schedule_messages/'>/messages/schedule/create</a>
    description: Schedule a campaign, Canvas, or other message to be sent at a designated time (up to 90 days in the future).
    tags:
      - Schedule Messages 
  - name: <a href='/docs/api/endpoints/messaging/schedule_messages/post_update_scheduled_triggered_canvases/'>/canvas/trigger/schedule/update</a>
    description: Update scheduled API-triggered Canvases that were created in the dashboard.
    tags:
      - Schedule Messages    
  - name: <a href='/docs/api/endpoints/messaging/schedule_messages/get_messages_scheduled/'>/messages/scheduled_broadcasts</a>
    description: Return a JSON list of information about scheduled campaigns and entry Canvases between now and a designated <code>end_time</code> specified in the request.
    tags:
      - Schedule Messages    
  - name: <a href='/docs/api/endpoints/subscription_groups/post_update_user_subscription_group_status/'>/subscription/status/set</a>
    description: Batch update the subscription state of up to 50 users on the Braze dashboard.
    tags:
      - Subscription Groups
  - name: <a href='/docs/api/endpoints/subscription_groups/post_update_user_subscription_group_status_v2/'>/v2/subscription/status/set</a>
    description: Batch update the subscription state of up to 50 users on the Braze dashboard.
    tags:
      - Subscription Groups
  - name: <a href='/docs/api/endpoints/subscription_groups/get_list_user_subscription_group_status/'>/subscription/status/get</a>
    description: Get the subscription state of a user in a subscription group.
    tags:
      - Subscription Groups
  - name: <a href='/docs/api/endpoints/subscription_groups/get_list_user_subscription_groups/'>/subscription/user/status</a>
    description: List and get the subscription groups of a certain user.
    tags:
      - Subscription Groups
  - name: <a href='/docs/api/endpoints/email/post_blacklist/'>/email/blacklist</a>
    description: Unsubscribe a user from email and mark them as hard bounced.
    tags:
     - Email List
  - name: <a href='/docs/api/endpoints/email/post_remove_hard_bounces/'>/email/bounce/remove</a>
    description: Remove email addresses from your Braze bounce list.
    tags:
      - Email List
  - name: <a href='/docs/api/endpoints/email/post_remove_spam/'>/email/spam/remove</a>
    description: Remove email addresses from your Braze spam list.
    tags:
     - Email List
  - name: <a href='/docs/api/endpoints/email/post_email_subscription_status/'>/email/status</a>
    description: Set the email subscription state for your users.
    tags:
     - Email List
  - name: <a href='/docs/api/endpoints/templates/email_templates/post_create_email_template/'>/templates/email/create</a>
    description: Create email templates on the Braze dashboard.
    tags:
     - Email Templates
  - name: <a href='/docs/api/endpoints/templates/email_templates/post_update_email_template/'>/templates/email/update</a>
    description: Update email templates on the Braze dashboard.
    tags:
     - Email Templates
  - name: <a href='/docs/api/endpoints/email/get_list_hard_bounces/'>/email/hard_bounces</a>
    description: Pull a list of email addresses that have "hard bounced" your email messages within a certain time frame.
    tags:
     - Email List
  - name: <a href='/docs/api/endpoints/email/get_query_unsubscribed_email_addresses/'>/email/unsubscribes</a>
    description: Return emails that have unsubscribed during the time period from <code>start_date</code> to <code>end_date</code>.
    tags:
     - Email List
  - name: <a href='/docs/api/endpoints/templates/email_templates/get_see_email_template_information/'>/templates/email/info</a>
    description: Get information on your email templates.
    tags:
     - Email Templates
  - name: <a href='/docs/api/endpoints/templates/email_templates/get_list_email_templates/'>/templates/email/list</a>
    description: Get a list of available email templates in your Braze account.
    tags:
     - Email Templates
  - name: <a href='/docs/api/endpoints/export/campaigns/get_campaign_analytics/'>/campaigns/data_series</a>
    description: Retrieve a daily series of various stats for a campaign over time.
    tags:
     - Campaigns
  - name: <a href='/docs/api/endpoints/export/campaigns/get_campaign_details/'>/campaigns/details</a>
    description: Retrieve relevant information on a specified campaign.
    tags:
      - Campaigns
  - name: <a href='/docs/api/endpoints/export/campaigns/get_campaigns/'>/campaigns/list</a>
    description: Export a list of campaigns, each of which will include its name, campaign API identifier, whether it is an API campaign, and tags associated with the campaign.
    tags:
      - Campaigns
  - name: <a href='/docs/api/endpoints/export/campaigns/get_send_analytics/'>/sends/data_series</a>
    description: Retrieve a daily series of various stats for a tracked <code>send_id</code>.
    tags:
      - Campaigns
  - name: <a href='/docs/api/endpoints/export/canvas/get_canvas_analytics/'>/canvas/data_series</a>
    description: Export time series data for a Canvas.
    tags:
      - Canvas
  - name: <a href='/docs/api/endpoints/export/canvas/get_canvas_analytics_summary/'>/canvas/data_summary</a>
    description: Export rollups of time series data for a Canvas, providing a concise summary of a Canvas' results.
    tags:
      - Canvas
  - name: <a href='/docs/api/endpoints/export/canvas/get_canvas_details/'>/canvas/details</a>
    description: Export metadata about a Canvas, such as the name, time created, current status, and more.
    tags:
      - Canvas
  - name: <a href='/docs/api/endpoints/export/canvas/get_canvases/'>/canvas/list</a>
    description: Export a list of Canvases, including the name, Canvas API identifier and associated tags.
    tags:
      - Canvas
  - name: <a href='/docs/api/endpoints/export/segments/get_segment_analytics/'>/segments/data_series</a>
    description: Retrieve a daily series of the estimated size of a segment over time.
    tags:
      - Segments
  - name: <a href='/docs/api/endpoints/export/segments/get_segment_details/'>/segments/details</a>
    description: Retrieve relevant information on a segment.
    tags:
      - Segments
  - name: <a href='/docs/api/endpoints/export/segments/get_segment/'>/segments/list</a>
    description: Export a list of segments, each of which will include its name, Segment API identifier, and whether it has analytics tracking enabled.
    tags:
      - Segments
  - name: <a href='/docs/api/endpoints/export/sessions/get_sessions_analytics/'>/sessions/data_series</a>
    description: Retrieve a series of the number of sessions for your app over a designated time period.
    tags:
      - Sessions
  - name: <a href='/docs/api/endpoints/export/custom_events/get_custom_events_analytics/'>/events/data_series</a>
    description: Retrieve a series of the number of occurrences of a custom event in your app over a designated time period.
    tags:
      - Custom Events
  - name: <a href='/docs/api/endpoints/export/custom_events/get_custom_events/'>/events/list</a>
    description: Export a list of custom events that have been recorded for your app.
    tags:
      - Custom Events
  - name: <a href='/docs/api/endpoints/templates/content_blocks_templates/post_create_email_content_block/'>/content_blocks/create</a>
    description: Create an email Content Block.
    tags:
      - Content Blocks
  - name: <a href='/docs/api/endpoints/templates/content_blocks_templates/post_update_content_block/'>/content_blocks/update</a>
    description: Update an email Content Block.
    tags:
      - Content Blocks
  - name: <a href='/docs/api/endpoints/templates/content_blocks_templates/get_see_email_content_blocks_information/'>/content_blocks/info</a>
    description: Call information for your existing email Content Block.
    tags:
      - Content Blocks
  - name: <a href='/docs/api/endpoints/templates/content_blocks_templates/get_list_email_content_blocks/'>/content_blocks/list</a>
    description: List your existing Content Blocks information.
    tags:
      - Content Blocks
  - name: <a href='/docs/api/endpoints/export/kpi/get_kpi_dau_date/'>/kpi/dau/data_series</a>
    description: Retrieve a daily series of the total number of unique active users on each date.
    tags:
      - KPI
  - name: <a href='/docs/api/endpoints/export/kpi/get_kpi_mau_30_days/'>/kpi/mau/data_series</a>
    description: Retrieve a daily series of the total number of unique active users over a 30-day rolling window.
    tags:
      - KPI
  - name: <a href='/docs/api/endpoints/export/kpi/get_kpi_daily_new_users_date/'>/kpi/new_users/data_series</a>
    description: Retrieve a daily series of the total number of new users on each date.
    tags:
      - KPI
  - name: <a href='/docs/api/endpoints/export/kpi/get_kpi_uninstalls_date/'>/kpi/uninstalls/data_series</a>
    description: Retrieve a daily series of the total number of uninstalls on each date.
    tags:
      - KPI
  - name: <a href='/docs/api/endpoints/export/news_feed/get_news_feed_card_analytics/'>/feed/data_series</a>
    description: Retrieve a daily series of engagement stats for a card over time.
    tags:
      - News Feed
  - name: <a href='/docs/api/endpoints/export/news_feed/get_news_feed_card_details/'>/feed/details</a>
    description: Retrieve relevant information on a card.
    tags:
      - News Feed
  - name: <a href='/docs/api/endpoints/export/news_feed/get_news_feed_cards/'>/feed/list</a>
    description: Export a list of News Feed cards, each of which will include its name and card API identifier.
    tags:
      - News Feed
  - name: <a href='/docs/api/endpoints/sms/post_remove_invalid_numbers/'>/sms/invalid_phone_numbers/remove</a>
    description: Remove "invalid" phone numbers from Braze's invalid list. This can be used to re-validate phone numbers after they have been marked as invalid.
    tags:
      - SMS
  - name: <a href='/docs/api/endpoints/sms/get_query_invalid_numbers/'>/sms/invalid_phone_numbers</a>
    description: Pull a list of phone numbers that have been deemed "invalid" within a certain time frame.
    tags:
      - SMS
  - name: <a href='/docs/api/endpoints/export/purchases/get_list_product_id/'>/purchases/product_list</a>
    description: Return a paginated lists of product IDs.
    tags:
      - Purchases
---