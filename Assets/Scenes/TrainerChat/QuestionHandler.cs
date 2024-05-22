using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FAQManager : MonoBehaviour
{
    public Button[] questionButtons; 

    public GameObject trainerTextPrefab; 
    public GameObject trainerImagePrefab; 
    public Transform contentPanel; 

    private int selectedCategoryID = 0; 
    private Vector2 trainerImagePosition = new Vector2(-100f, 408f);
    private Vector2 trainerTextPosition = new Vector2(300f, 408f);

    /*                
     * 
     */
    // Categories of questions
    private string[][] questions = new string[][]
    {
        //General
        new string[] { "What is the best way to warm up before exercising?", 
            "How long should a typical workout session be?", 
            "How often should I work out each week?",
            "What are the benefits of regular exercise?",
            "What are some tips for staying motivated to work out?" }, // General
        new string[] { "How do I create a balanced workout routine?",
            "What are some effective full-body workout routines?",
            "How can I vary my workouts to avoid a plateau?",
            "What is high-intensity interval training (HIIT)?",
            "What are the benefits of yoga and how can I incorporate it into my routine?"}, // Programs
        new string[] { "How can I prevent injuries while exercising?", 
            "What should I do if I feel pain during a workout?", 
            "What are some good stretches to do after a workout?", 
            "How important is rest and recovery?", 
            "What are the signs that I need to take a break from exercising?" }, // Injury
        new string[] {"What are the best exercises for building chest muscles?",
            "How do I perform a bench press correctly?","What is the difference between incline and decline bench press?"
            ,"How can I avoid shoulder injuries when doing chest exercises?",
            "What are some effective chest workouts for beginners?"}, //Chest
        new string[] {"What are the most effective exercises for targeting the abs?",
            "How do I perform a proper plank?","What is the best way to reduce belly fat?",
            "How often should I train my abs?","What are some common mistakes to avoid when doing ab workouts?"},
        new string[] {
            "What exercises are best for building shoulder muscles?",
            "How do I perform a shoulder press correctly?",
            "What are some good stretches for the shoulders?",
            "How can I prevent shoulder injuries while working out?",
            "What are some effective shoulder workouts for beginners?"
        }, // Shoulder questions
        new string[] {
            "What are the best exercises for building leg muscles?",
            "How do I perform a squat correctly?",
            "What is the difference between lunges and squats?",
            "How often should I train my legs?",
            "What are some common mistakes to avoid during leg workouts?"
        }, // Leg questions
        new string[] {
            "What are the best exercises for building bicep muscles?",
            "How do I perform a bicep curl correctly?",
            "What are some effective bicep workouts for beginners?",
            "How can I avoid elbow injuries while doing bicep exercises?",
            "What are the benefits of using free weights vs. machines for bicep workouts?"
        }, // Biceps questions
        new string[] {
            "What are the best exercises for building tricep muscles?",
            "How do I perform a tricep dip correctly?",
            "What are some effective tricep workouts for beginners?",
            "How can I prevent elbow injuries while doing tricep exercises?",
            "What is the difference between tricep pushdowns and overhead extensions?"
        }, // Triceps questions
        new string[] {
            "What are the best exercises for building back muscles?",
            "How do I perform a pull-up correctly?",
            "What are some effective back workouts for beginners?",
            "How can I avoid lower back injuries while working out?",
            "What are the benefits of using free weights vs. machines for back workouts?"
        }, // Back questions
        new string[] {
            "What are the best exercises for improving cardiovascular health?",
            "How often should I do cardio workouts?",
            "What is the difference between HIIT and steady-state cardio?",
            "How can I make cardio workouts more interesting?",
            "What are some common mistakes to avoid during cardio workouts?"
        } // Cardio questions
    };


    private string[][] answers = new string[][]
    {
        new string[] // General Fitness answers
        {
            "The best way to warm up is to start with light cardio exercises like jogging or jumping jacks to increase your heart rate and blood flow to muscles, followed by dynamic stretches.",
            "A typical workout session should be about 45 minutes to an hour, including warm-up and cool-down periods.",
            "You should aim to work out at least 3-5 times per week, depending on your fitness goals and schedule.",
            "Regular exercise improves cardiovascular health, strengthens muscles, boosts mental health, helps with weight management, and increases overall energy levels.",
            "Set realistic goals, track your progress, vary your workouts to keep them interesting, find a workout buddy, and reward yourself for reaching milestones."
        },
        new string[] // Exercise Program answers
        {
            "Structure your weekly routine by balancing different types of exercises: strength training, cardio, flexibility, and rest days.",
            "Strength training focuses on building muscle mass and strength through resistance exercises, while cardio workouts improve health by increasing your heart rate.",
            "Progress your workouts by gradually increasing the intensity, duration, or resistance, and incorporating new exercises to challenge your body.",
            "For weight loss, focus on high-intensity interval training (HIIT), strength training to build muscle (which increases metabolism), and maintaining a healthy diet.",
            "Create a balanced exercise program by including a variety of workouts (strength, cardio, flexibility), setting achievable goals, and listening to your body."
        },
        new string[] // Injury Prevention answers
        {
            "Common exercise-related injuries include sprains, strains, and tendinitis. Avoid them by using proper form, warming up, cooling down, and not overexerting yourself.",
            "Proper form is crucial to avoid injuries and maximize the effectiveness of your exercises.",
            "If you feel pain during a workout, stop immediately and assess the situation. Consult a professional if the pain persists.",
            "To prevent muscle soreness, cool down properly after workouts, stay hydrated, and consider incorporating stretching or foam rolling into your routine.",
            "Recover from an injury by resting, applying ice to the affected area, and gradually returning to exercise. Consult a healthcare provider for a tailored recovery plan."
        },
        new string[] {
            "The best exercises for building chest muscles are bench press, push-ups, and chest flyes.",
            "To perform a bench press correctly, lie on the bench with your feet flat on the ground, and lower the bar to your chest before pressing it back up.",
            "Incline bench press targets the upper part of your chest, while decline bench press targets the lower part of your chest.",
            "To avoid shoulder injuries, ensure proper form, warm up before exercises, and avoid lifting too heavy too soon.",
            "Effective chest workouts for beginners include push-ups, dumbbell presses, and chest flyes with light weights."
        }, // Chest answers
        new string[] {
            "The most effective exercises for targeting the abs are crunches, leg raises, and planks.",
            "To perform a proper plank, keep your body in a straight line from head to heels, with your elbows directly under your shoulders and core engaged.",
            "The best way to reduce belly fat is through a combination of a healthy diet, regular cardio, and strength training exercises.",
            "You should train your abs 2-3 times per week, allowing rest days in between for recovery.",
            "Common mistakes to avoid during ab workouts include pulling on your neck during crunches, not engaging your core fully, and using momentum instead of muscle strength."
        }, // Abs answers
        new string[] {
            "The best exercises for building shoulder muscles are shoulder presses, lateral raises, and front raises.",
            "To perform a shoulder press correctly, sit or stand with a straight back, hold the weights at shoulder height, and press upwards without locking your elbows.",
            "Good stretches for the shoulders include the cross-body shoulder stretch and the overhead shoulder stretch.",
            "To prevent shoulder injuries, use proper form, avoid overloading weights, and ensure adequate warm-up and stretching before workouts.",
            "Effective shoulder workouts for beginners include light dumbbell shoulder presses, lateral raises, and front raises."
        }, // Shoulder answers
        new string[] {
            "The best exercises for building leg muscles are squats, lunges, and leg presses.",
            "To perform a squat correctly, lower your body as if sitting back into a chair, keep your chest up and knees over your toes,and then return to standing.",
            "Lunges target the quads, glutes, and hamstrings similarly to squats, but lunges also engage stabilizing muscles due to the forward step.",
            "You should train your legs 2-3 times per week, allowing rest days in between for recovery.",
            "Common mistakes to avoid include letting your knees go past your toes during squats, not lowering yourself fully during exercises,and not engaging your core."
        }, // Leg answers
        new string[] {
            "The best exercises for building bicep muscles are bicep curls, hammer curls, and chin-ups.",
            "To perform a bicep curl correctly, hold the weights with an underhand grip, and curl the weights up while keeping your elbows close to your sides.",
            "Effective bicep workouts for beginners include light dumbbell bicep curls, hammer curls, and resistance band curls.",
            "To avoid elbow injuries, use proper form, avoid lifting too heavy too soon, and ensure adequate warm-up and stretching before workouts.",
            "Using free weights for bicep workouts engages more stabilizing muscles, while machines can help maintain proper form and reduce injury risk."
        }, // Biceps answers
        new string[] {
            "The best exercises for building tricep muscles are tricep dips, tricep pushdowns, and overhead tricep extensions.",
            "To perform a tricep dip correctly, place your hands on a bench behind you, lower your body until your elbows are at a 90-degree angle, and then push back up.",
            "Effective tricep workouts for beginners include bench dips, light tricep pushdowns, and overhead tricep extensions with a light weight.",
            "To prevent elbow injuries, use proper form, avoid overloading weights, and ensure adequate warm-up and stretching before workouts.",
            "Tricep pushdowns target the lateral head of the tricep, while overhead extensions focus more on the long head."
        }, // Triceps answers
        new string[] {
            "The best exercises for building back muscles are pull-ups, bent-over rows, and deadlifts.",
            "To perform a pull-up correctly, pull your body up until your chin is above the bar, and then lower back down with control.",
            "Effective back workouts for beginners include assisted pull-ups, light bent-over rows, and resistance band rows.",
            "To avoid lower back injuries, use proper form, engage your core during exercises, and avoid lifting too heavy too soon.",
            "Using free weights for back workouts engages more stabilizing muscles, while machines can help maintain proper form and reduce injury risk."
        }, // Back answers
        new string[] {
            "The best exercises for improving cardiovascular health are running, cycling, swimming, and jump rope.",
            "You should do cardio workouts 3-5 times per week, depending on your fitness level and goals.",
            "HIIT (High-Intensity Interval Training) involves short bursts of intense activity followed by rest, while steady-state cardio involves maintaining a consistent, moderate intensity.",
            "To make cardio workouts more interesting, try varying your routine, using different equipment, and setting new challenges.",
            "Common mistakes to avoid during cardio workouts include overtraining, not warming up properly, and using improper form."
        } // Cardio answers
    };

    void Start()
    {
        selectedCategoryID = PlayerPrefs.GetInt("SelectedCategory", 0);

        
        if (selectedCategoryID < 0 || selectedCategoryID >= questions.Length)
        {
            Debug.LogError("Invalid selectedCategoryID: " + selectedCategoryID);
            return;
        }

        SetupQuestionButtons();
    }

    void SetupQuestionButtons()
    {
        string[] currentQuestions = questions[selectedCategoryID];

        for (int i = 0; i < questionButtons.Length; i++)
        {
            TMP_Text buttonText = questionButtons[i].GetComponentInChildren<TMP_Text>();

            if (i < currentQuestions.Length)
            {
                if (buttonText != null)
                {
                    buttonText.text = currentQuestions[i];
                    questionButtons[i].gameObject.SetActive(true); 
                }
                else
                {
                    Debug.LogError("TMP_Text component not found in question button.");
                    questionButtons[i].gameObject.SetActive(false); 
                }

               
                questionButtons[i].onClick.RemoveAllListeners();

                
                int index = i; 
                questionButtons[i].onClick.AddListener(() => ShowTrainerResponse(index));
            }
            else
            {
                questionButtons[i].gameObject.SetActive(false); 
            }
        }
    }

    void ShowTrainerResponse(int index)
    {
        if (index < 0 || index >= answers[selectedCategoryID].Length)
        {
            Debug.LogError("Invalid index: " + index);
            return;
        }

        
        GameObject trainerImage = Instantiate(trainerImagePrefab, contentPanel);
        if (trainerImage == null)
        {
            Debug.LogError("Failed to instantiate trainerImagePrefab.");
            return;
        }

        RectTransform imageRect = trainerImage.GetComponent<RectTransform>();
        if (imageRect != null)
        {         
            imageRect.anchoredPosition = new Vector2(trainerImagePosition.x, trainerImagePosition.y - index * 200f);
        }
        else
        {
            Debug.LogError("RectTransform component not found in trainerImagePrefab.");
        }

        
        GameObject trainerText = Instantiate(trainerTextPrefab, contentPanel);
        if (trainerText == null)
        {
            Debug.LogError("Failed to instantiate trainerTextPrefab.");
            return;
        }

        TMP_Text trainerTextComponent = trainerText.GetComponentInChildren<TMP_Text>();
        if (trainerTextComponent == null)
        {
            Debug.LogError("TMP_Text component not found in trainerTextPrefab.");
            return;
        }
       // else
       // {
         //   trainerTextComponent.text =  answers[selectedCategoryID][index];
         //   LayoutRebuilder.ForceRebuildLayoutImmediate(trainerText.GetComponent<RectTransform>());
       // }

        try
        {
            trainerTextComponent.text = answers[selectedCategoryID][index];
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error setting text: " + ex.Message);
        }

        RectTransform textRect = trainerText.GetComponent<RectTransform>();
        if (textRect != null)
        {
           
            textRect.anchoredPosition = new Vector2(trainerTextPosition.x, trainerTextPosition.y - index * 200f);
        }
        else
        {
            Debug.LogError("RectTransform component not found in trainerTextPrefab.");
        }
    }
}
















