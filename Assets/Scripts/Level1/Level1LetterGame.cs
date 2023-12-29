using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class Leve1LetterGame : MonoBehaviour
{
    public TMP_InputField[] inputFields; //Array for input fields

    //Correct answers.
    private string[] correctAnswers = { "wind", "tea", "stories" }; 

    private GameData _data;

    public int love;

    public VignetteController vignetteController;

    public void Start()
    {
        love = 1;
        _data = DataManager.DM.Read();  
        vignetteController.SetFrequency(0.5f);
        vignetteController.SetMinAlpha(0.1f);
        vignetteController.SetMaxAlpha(0.4f);
    }

    public void CheckAnswers()
    {
        int score = 0; //Score counter
        int totalQuestions = inputFields.Length; //Total questions counter
        for (int i = 0; i < inputFields.Length; i++)
        {
            if (inputFields[i].text.ToLower() == correctAnswers[i].ToLower())
            {
                inputFields[i].textComponent.color = Color.green; // Change text color to green for correct answers.
                inputFields[i].readOnly = true; // Make input field read only.
                score += 1; // Add 1 to score for each correct answer.
            }
            else
            {
                inputFields[i].textComponent.color = Color.red; // Change text color to red for incorrect answers.
            }
        }
        love = score;
        if(love == 1)
        {
            vignetteController.SetFrequency(2.0f);
            vignetteController.SetMinAlpha(0.1f);
            vignetteController.SetMaxAlpha(0.5f);
        }
        else if (love == 2)
        {
            vignetteController.SetFrequency(4.0f);
            vignetteController.SetMinAlpha(0.3f);
            vignetteController.SetMaxAlpha(0.6f);
        }
        else if (love == 3)
        {
            vignetteController.SetFrequency(6.0f);
            vignetteController.SetMinAlpha(0.4f);
            vignetteController.SetMaxAlpha(0.7f);
        }

        if(score == totalQuestions)
        {
            Debug.Log("You got all the answers correct!");
            _data.completed[0] = true;
            DataManager.DM.Write(_data);
            Debug.Log(JsonUtility.ToJson(DataManager.DM.Read()));
            SceneManager.LoadScene("Hub"); // Load next scene.
        }
        else
        {
            Debug.Log("You got " + score + " out of " + totalQuestions + " correct!");
        }
    }
}