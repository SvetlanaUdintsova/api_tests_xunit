# Trying xUnit with HttpClient and RestSharp

This project is a sandbox for learning the xUnit and RestSharp.

The public API taken for test is the norwegian weather provider [api.met.no](https://api.met.no/weatherapi/locationforecast/2.0/documentation)

ATTENTION! The creator of API specifies how exactly API can be consumed without breaking code of conduct on [Terms of Service](https://api.met.no/doc/TermsOfService) section.

## Configuration

Before running this project, you **must** prepopulate the `appsettings.json` file with your correct data. The file requires the following variables:

```json
{
  "AppSettings": {
    "ContactEmail": "your_email@example.com",
    "UserAgent": "Your project name"
  }
}
```

- **ContactEmail**: Your email address (required by the api.met.no API for identification)
- **UserAgent**: Your application name or identifier

Replace the placeholder values with your actual email and project name before running the tests.
