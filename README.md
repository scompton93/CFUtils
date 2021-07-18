# CFMXCompat

Use CFMX Compat encryption in C#.

## Description

This replicates the functionality of ColdFusions "encrypt" function in C#, specifically the UU encoded CFMX_Compat alogrithim.

This is simply a C# fork of TommyWo's CFMX Compat for Java (https://github.com/tommywo/cfmx_compat).

This could be further turned into a CLR function for SQL Server to decrypt/encrypt values in the database or as an extension for New Atlantas Blue Dragon (which doesnt implement CFMXCompat)

## Usage

```
ColdFusion.CFMXCompat.encrypt(Value, "YourSeedStringHere");
```

You may also be URL Encoding it in ColdFusion for compatibility you can do:
```
WebUtility.UrlEncode(ColdFusion.CFMXCompat.encrypt(Value, "YourSeedStringHere"));
```

Decryption
```
ColdFusion.CFMXCompat.decrypt(WebUtility.UrlDecode(Value), "YourSeedStringHere");
```
