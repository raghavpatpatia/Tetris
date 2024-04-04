using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class AuthManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private Button loginButton;
    [SerializeField] private Button signupButton;
    [SerializeField] private int sceneIndex;
    [SerializeField] private GameObject hoverObject;
    [SerializeField] private TextMeshProUGUI hoverText;
    
    private HoverObjectController hoverObjectController;
    private async void Awake()
    {
        try
        {
            await UnityServices.InitializeAsync();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void Start()
    {
        hoverObjectController = new HoverObjectController(hoverObject, hoverText);
        loginButton.onClick.AddListener(SignIn);
        signupButton.onClick.AddListener(SignUp);
    }

    private async void SignUp()
    {
        string userName = this.userName.text;
        string password = this.password.text;

        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(userName, password);
            await AuthenticationService.Instance.UpdatePlayerNameAsync(userName);
            LoadScene();
        }
        catch (AuthenticationException ex)
        {
            ClearInputFields();
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            await hoverObjectController.LoginFailed(2f, "Sign Up failed...");
            ClearInputFields();
            Debug.LogException(ex);
        }
    }

    private async void SignIn()
    {
        string userName = this.userName.text;
        string password = this.password.text;

        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(userName, password);
            LoadScene();
        }
        catch (AuthenticationException ex)
        {
            ClearInputFields();
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            await hoverObjectController.LoginFailed(2f, "Log In failed...");
            ClearInputFields();
            Debug.LogException(ex);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    private void ClearInputFields()
    {
        userName.text = "";
        password.text = "";
    }
}
