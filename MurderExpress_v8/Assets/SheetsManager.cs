using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;


public class SheetsManager : MonoBehaviour
{
    static readonly string[] Scopes = { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets };

    static readonly string ApplicationName = "mExpressData";

    static readonly string SpreadsheetId = "1VRrW7bAZvSu4C-SGl3py-ys3AguMIMZF-rP1zwxij3g";

    static readonly string sheet = "Sheet1";

    static Google.Apis.Sheets.v4.SheetsService service;

    static public List<string> Usernames = new List<string>();
    static public List<string> Times = new List<string>();

    public DisplayLeaderboard displayLeaderboard;

    void Start()
    {
        Usernames.Clear();
        Times.Clear();

        // if (PlayerData.NeedsAddData)
        // {
        //     Debug.Log("Need to add data");
        //     CreateEntry();
        //     PlayerData.NeedsAddData = false;
        // }

        Google.Apis.Auth.OAuth2.GoogleCredential credential;
        string credentialString = Resources.Load("client_secrets", typeof(TextAsset)).ToString();
        credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromJson(credentialString).CreateScoped(Scopes);
        //using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
        //{
        //    credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromStream(stream).CreateScoped(Scopes);
        //}

        service = new Google.Apis.Sheets.v4.SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });
        
        ReadEntries();
        displayLeaderboard.Display();
    }

    static void ReadEntries()
    {
        var range = $"{sheet}!D2:E9";
        var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
        
        var response = request.Execute();
        var values = response.Values;
        
        if (values != null && values.Count > 0)
        {
            
            foreach (var row in values)
            {
                // the given "rows" actually represent columns in the sheet
                //string message = "{0} | {1} {2} {3} | {4} {5} {6} | {7} {8} {9}", row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9]
                Usernames.Add($"{row[0]}");
                Times.Add($"{row[1]}");
                
            }

            
        }
        else
        {
            Debug.Log("No data was found");
        }
    }

    static void CreateEntry()
    {
        var range = "RawData!A:O";
        var valueRange = new Google.Apis.Sheets.v4.Data.ValueRange();
        
        var objectList = new List<object>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "L", "K", "L", "M", "N", "O"};
        
        valueRange.Values = new List<IList<object>> {objectList };
        
        var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
        Debug.Log("Created request");
        appendRequest.ValueInputOption = Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        //Debug.Log("Set input option");
        var appendResponse = appendRequest.Execute();
        //Debug.Log("executed");
    }
}
