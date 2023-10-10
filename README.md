## Music Mixer API and Console Application

### 👩‍🏫 Introduction
This is a REST API in C# with personal music information and a Console Application to consume that API and return either a random set of tracks and information or the complete list of tracks from the in-memory data.

### 🍀 Endpoints
There are two endpoints available:
1. Get a complete list of available tracks: <br>*/MusicMixer/get_music_mix*</br>
2. Get a random track: <br>*/MusicMixer/get_random_track* </br>

### 💻 How to start application locally
1. Clone repository by running the following command in the terminal: `git clone git@github.com:AlmaFreiesleben/MusicMixer.git`.
2. Open up two seperate terminals. 
3. From the root folder */MusicMixer* navigate into respectively */MusicMixerAPI* in one terminal and */MusicMixerConsole* in the other.

#### MusicMixerAPI 
1. Build and run the REST API from terminal with following command: `dotnet run --launch-profile https` or `dotnet run`. The first creates a secure https connection.
2. Go to either https://localhost:7190 or http://localhost:5153 in a browser to test the application.
    1. To call the api add the name of the endpoint e.g. */MusicMixer/get_random_track*. The result is shown as JSON in the browser.
    2. Enable swagger UI by adding */swagger/index.html* to the URL e.g. https://localhost:7190/swagger/index.html.
3. Press Ctrl+C at the terminal to stop the app (don't do this before you are entirely done, the API needs to run to be consumed by the console application).

#### MusicMixerConsole
1. Build and run the Console Application from terminal with following command: `dotnet run` or `dotnet run -- 4`.
    1. `dotnet run` returns the complete list of tracks from memory.
   <img src="/Resources/dotnet%20run%20--%202.png" alt="The complete list of track as a table with 4 columns ("Artist", "Title", "Description", "Goes With")." width="200">
    ![The complete list of track as a table with 4 columns ("Artist", "Title", "Description", "Goes With").](/Resources/dotnet%20run%20--%202.png)
    3. `dotnet run -- 4` returns the user specified amount of tracks, in this case 4.
    ![Example of random track list of the size specified by the user, in this case 2.](/Resources/dotnet%20run.png)
2. Press Ctrl+C at the terminal to stop the app.

#### 🔭 Future work

- API for database or use Spotify API.
- Better testing and errorhandling.
- Containerize and setup CI pipeline. 

