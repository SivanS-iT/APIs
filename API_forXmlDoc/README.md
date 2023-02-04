## API for getting values from XML document

Soul purpose of this API practice is just to play with swagger and API. 
I made an API call and in the JSON code you can change certain things that you can get as a response from the xml file (XML file is already in repository ).

## Example below:

First you need to enter file path of xml file!

Example of JSON file as REQUEST;
``` JSON
{
  "channelRequest": [
    {
      "channelName": "train1",
      "getTestResult": true,
      "getSpectralAnalysisResult": true,
      "getKurtosisResult": true,
      "getOrderTrackDefinitionResult": true,
      "getOrderTrackDefinitionResultByName": [
        
      ]
    },
    {
      "channelName": "train2",
      "getTestResult": true,
      "getSpectralAnalysisResult": true,
      "getKurtosisResult": true,
      "getOrderTrackDefinitionResult": true,
      "getOrderTrackDefinitionResultByName": [
        1, 2, 3
      ]
    }


  ]
}
```

And example of RESPONSE (if you entered right file path):
``` JSON
{
  "testPassed": true,
  "testResultId": 2023,
  "measurementChannel": [
    {
      "channelName": "Train1",
      "testResult": false,
      "spectralAnalysisResult": true,
      "peak": 11111,
      "kurtosisResult": false,
      "orderTrackDefinition": []
    },
    {
      "channelName": "Train2",
      "testResult": false,
      "spectralAnalysisResult": false,
      "peak": 22222,
      "kurtosisResult": false,
      "orderTrackDefinition": [
        {
          "orderTrackDefinitionName": "1",
          "orderTrackDefinitionResultOk": true
        },
        {
          "orderTrackDefinitionName": "2",
          "orderTrackDefinitionResultOk": true
        },
        {
          "orderTrackDefinitionName": "3",
          "orderTrackDefinitionResultOk": true
        }
      ]
    }
  ]
}
 ```


