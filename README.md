# ssotme-ms-airtable-ionic-sassymq-seed
An Ionic Sassy Seed based on an Airtable.com base.


For a full project roadmap, including: [Roadmap Airtable Template](https://airtable.com/shriiZMSnMwtOUKY3)

 - Roadmap - Project Phases/Budget
 - User Stories
 - Actors
 - Lexicon - API
 - Entities - things
 - App States
 - Settings

Or, for an empty starting project, use this: [Empty Airtable Template](https://airtable.com/shrGgWOuXXxhZls1c)

## Using this Seed:

1. Clone this repo locally

2. Open one of the airtables above

3. Click *copy base* in the top right corner to create a copy in your account

4. Customize the Airtable, following the patterns established.

5. Open the API Documentation and choose *show API key* in the top right corner.  Copy your 
airtable base id and api key from the documentation.
 - https://api.airtable.com/v0/{THIS_IS_THE_BASE_ID}/Roadmap?api_key={THIS_IS_YOUR_API_KEY}
 - The `baseId` will start *app*XYZ123 and the `apiKey` will start out *key*XYZ123.

5. Update the first tool in the SSoT.me Project (Airtable-to-Xml) to include the baseId and 
apiKey copied from the documentation above. 

6. Open a powershell prompt in the repo root folder, and type `>ssotme -init`.  
The name of the project will be inferred from the name of the folder.

 - *NOTE* - if the `Base ID` OR `API KEY` is wrong - it will be reported right away in the 
 init process as a 404 error on Airtable.

8. Move into the `/ionic-ts-sidemenu/` folder and type `>prep-ionic.bat` to 
start the ionic project downloading npm packages and building the mobile app.

10. Run the `/SqlServer/CreateUpdateSchema.sql` to create (or update the schema for) a SQL Server Database.

7. Open the SLN file that will be in the root project

9. In the visual studio project, open `/CoreLibrary/SassyMQ/` and include the 3 `.cs` 
files which are not automatically included.

9. In the visual studio project, open `/MVCRestAPI/Controllers/` and include the `api/*Controller.cs` 
rest api controllers which are not automatically included in the project when detected.

11. Make the `MVCRestAPI` the startup project in the solution.

12. Press F5 to run the project.  This will start the REST API.

13. in the `/ionic-ts-sidemenu/` run `ionic server` to start the Ionic Mobile app.  

Et Voila! - "spreadsheet" to mobile app in less than 10 minutes.


