using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using System.Collections.Generic;
using HtmlAgilityPack;

public class MatchFetcher : MonoBehaviour
{
    [SerializeField] private MatchCreator _matchCreator;

    private string _urlBase;
    private HtmlDocument _webData;
    private List<MatchParameters> _matchResults;

    void Start()
    {
        _urlBase = "https://www.championat.com/stat/football/#";
        _webData = new HtmlDocument();
        _matchResults = new List<MatchParameters>();

        StartCoroutine(GetWebData());
    }

    IEnumerator GetWebData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(GetUrl()))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.ConnectionError || webRequest.result != UnityWebRequest.Result.ProtocolError)
            {
                string webDataText = webRequest.downloadHandler.text;

                ParseScores(webDataText);

                if (_matchResults.Count > 0)
                {
                    foreach (var match in _matchResults)
                    {
                        _matchCreator.Create(match);
                    }
                }
            }
        }
    }

    private string GetUrl()
    {
        DateTime yesterday = DateTime.Today.AddDays(-1);
        string formattedDate = yesterday.ToString("yyyy-MM-dd");

        string url = _urlBase + formattedDate;

        return url;
    }

    void ParseScores(string html)
    {
        _webData.LoadHtml(html);

        var teamNameNodes = _webData.DocumentNode.SelectNodes("//a[not(@class)]");

        foreach (var node in teamNameNodes)
        {
            string text = node.InnerText;

            if (text.Contains(":") && text.Contains("–"))
            {
                Debug.Log(text);

                string[] parts1 = text.Split('–', StringSplitOptions.RemoveEmptyEntries);
                string team1 = parts1[0].Trim();
                string[] parts2 = parts1[1].Split(':');
                string team2Score = parts2[1].Trim();
                string team2AndTeam1Score = parts2[0];
                string[] part3 = team2AndTeam1Score.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string team1Score = part3[part3.Length - 1].Trim();

                string team2 = string.Empty;

                for (int i = 0; i < part3.Length - 1; i++)
                {
                    team2 += part3[i] + " ";
                }

                string score = team1Score + " : " + team2Score;

                MatchParameters match = new MatchParameters(team1, team2, score);

                _matchResults.Add(match);
            }
        }
    }
}
