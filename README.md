# AsIKnow.LocalizationHelpers

Localization helpers

## Usage ##

In order to use the library it's necessary to call the _UseLocalizationHelpers_ extension method during application _Configure_.

<pre>

	app.UseLocalizationHelpers(options);

</pre>

The _options_ object has the following attributes:

* DefaultCulture (string)
* SupportedCultures (string[])

Example configuration:

<pre>
"Localization": {
	"DefaultCulture": "it-IT",
	"SupportedCultures": [
	  "it",
	  "it-IT",
	  "en-AU",
	  "en-GB",
	  "en",
	  "es-ES",
	  "es-MX",
	  "es",
	  "fr-FR",
	  "fr"
	]
}
</pre>