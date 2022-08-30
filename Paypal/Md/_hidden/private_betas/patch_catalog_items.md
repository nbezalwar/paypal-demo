---
nav_title: "PATCH: Catalog Items Bulk Patch"
permalink: /catalogs_items_patch/
hidden: true
layout: api_page

---
{% api %}
# Edit catalog items in bulk
{% apimethod patch %}
/catalogs/catalog_name/items
{% endapimethod %}

Use this endpoint to bulk edit items in your catalog. Each request can support up to 50 items.

{% alert important %}
Support for the this endpoint is currently in early access. Contact your Braze account manager if you are interested in participating in the early access.
{% endalert %}

## Rate limit

This endpoint has a rate limit of 100 requests per minute.

## Request body

```
Content-Type: application/json
Authorization: Bearer YOUR-REST-API-KEY
```

```json
{
    "items": [
        {
            "id": "0",
            "count": 5
        },
        {
            "id": "1",
            "count": 10
        }
        // ... max of 50 items
    ]
}
```

## Example error response 

```json
Content-Type: application/json
Authorization: Bearer YOUR-REST-API-KEY
{
  "errors": [
    {
      "id": "catalog-not-found",
      "message": "Could not find catalog",
      "parameters": [
        "catalog_name"
      ],
      "parameter_values": [
        "catalog_name"
      ]
    }
  ]
}
```

## Possible errors

The following table lists possible returned errors and their associated troubleshooting steps, if applicable.

| Error | Troubleshooting |
| --- | --- |
| catalog-not-found | Check that the catalog name is valid. |
| invalid-ids | Item IDs can only include letters, numbers, hyphens, and underscores. |
| ids-too-large | Item IDs can't be more than 250 characters. |
| items-too-large | Item values can't exceed 5,000 characters. |
| referenced-same-id-multiple-times | Item IDs must be unique in the request. |
| request-includes-too-many-items | Your request has too many items. The maximum is 50.
| fields-do-not-match | Updated fields must match the fields in the catalog. |
| unable-to-coerce | Item types can be converted. |
| arbitrary-error | An arbitrary error occurred. Please try again or contact [Support]({{site.baseurl}}/support_contact/). |
{: .reset-td-br-1 .reset-td-br-2}

{% endapi %}