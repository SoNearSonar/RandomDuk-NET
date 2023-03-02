# RandomDukNET
## A C# API wrapper written in .NET 6.0 LTS for the website Random-d.uk. A website that has images of ducks

## Credits:
- [Geoffrey Westhoff](https://geoffreywesthoff.nl/) - [Random-d.uk](https://random-d.uk) & [Random-d.uk API](https://random-d.uk/api)

## Example Use:
### Getting Random Image:
```csharp
RandomDukManager manager = new RandomDukManager();
byte[] image = await manager.GetRandomImage();

File.WriteAllBytes("duck_image_random.jpg", image);
```

### Getting Jpeg Duck Image By ID:
```csharp
RandomDukManager manager = new RandomDukManager();
byte[] image = await manager.GetDuckImageJpegById(1); // Takes in a number representing a ID

File.WriteAllBytes("duck_image_1.jpg", image);
```

### Getting Http Duck Image:
```csharp
RandomDukManager manager = new RandomDukManager();
byte[] image = await manager.GetHttpDuckImage(400); // Takes in a number representing a status code

File.WriteAllBytes("duck_image_400error.jpg", image);
```

### Getting Duk JSON Object:
```csharp
RandomDukManager manager = new RandomDukManager();
Duk dukObject = await manager.GetRandom(); // await manager.GetQuack(); also does the same

Assert.IsNotNull(dukObject);
Assert.IsNotNull(dukObject.Message); // Message of duck image
Assert.IsNotNull(dukObject.Url); // Url pointing to the file of duck image
```

### Getting List Of Image Filenames in JSON:
```csharp
RandomDukManager manager = new RandomDukManager();
DukList duckList = await manager.GetImageList();

Assert.IsNotNull(result);
Assert.IsTrue(result.ImageFilenames.Count != 0); // List of all jpeg file names stored on the web server
Assert.IsTrue(result.GifFilenames.Count != 0); // List of all gif file names stored on the web server
Assert.IsTrue(result.HttpDuckFilenames.Count != 0); // List of all http duck file names stored on the web server
Assert.IsTrue(result.ImageCount != 0); // Number of jpeg images on the web server
Assert.IsTrue(result.GifCount != 0); // Number of gif images on the web server
```
