using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Clicker.Tools;

namespace Clicker.GameLogic
{
    public sealed class TaskSolve : MonoBehaviour
    {

        [SerializeField] private TMP_InputField _answerField;
        [SerializeField] private Button _solveButton;
        [SerializeField] private TextMeshProUGUI _firstNumber;
        [SerializeField] private TextMeshProUGUI _secondNumber;

        [SerializeField] private TaskWindow _window;
        private readonly int[] _numbers = new int[] { 2, 3, 7, 4, 5, 9 };
        private int _result;
        private string _answerText;

        private void Start()
        {
            _solveButton.onClick.AddListener(_window.Show);
            _answerField.onValueChanged.AddListener(SetAnswer);
        }

        private void OnEnable()
        {
            _window.Disable();
            _answerField.text = null;
            SetNumbers();
        }

        private void OnDestroy()
        {
            _solveButton.onClick.RemoveListener(_window.Show);
            _answerField.onValueChanged.RemoveListener(SetAnswer);
        }

        private void SetNumbers()
        {
            var firstNumber = UnityEngine.Random.Range(0, _numbers.Length);
            var secondNumber = UnityEngine.Random.Range(0, _numbers.Length);
            _firstNumber.text = firstNumber.ToString();
            _secondNumber.text = secondNumber.ToString();
            _result = CalculationSigns.GetResult(firstNumber, secondNumber, _window.Signs);
            _window.SetResult(_result);
        }

        private void SetAnswer(string answer)
        {
            _answerText = answer;
            _window.SetAnswerText(_answerText);
        }
    }
}
