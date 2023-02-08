using UnityEngine;
public class СhangeСolorСube : MonoBehaviour
{
   [SerializeField] private float _ColorhueMin;
   [SerializeField] private float _ColorhueMax = 1f;
   [SerializeField] private float _ColorsaturationMin = 0.8f;
   [SerializeField] private float _ColorsaturationMax = 1f;
   [SerializeField] private float _ColorvalueMin = 1f;
   [SerializeField] private float _ColorvalueMax = 1f;
   
   [SerializeField]
   private float _recoloringDuration = 2f;

   [SerializeField]
   private float _timer;

   [SerializeField]
   private float _waitingTime = 5f;
   
   private Color _startColor;
   private Color _nextColor;
   private Renderer _renderer;
   private float _recoloringTime;

   private void Awake()
   {
      _renderer = GetComponent<Renderer>();
      GeneratorNextColor();
   }

   private void GeneratorNextColor()
   {
      _startColor = _renderer.material.color;
      _nextColor = Random.ColorHSV(_ColorhueMin, _ColorhueMax, _ColorsaturationMin, _ColorsaturationMax, _ColorvalueMin, _ColorvalueMax);
   }

   private void Update()
   {
      _recoloringTime += Time.deltaTime;
      
      var progress = _recoloringTime / _recoloringDuration;
      var currentColor = Color.Lerp(_startColor, _nextColor, progress);

      _renderer.material.color = currentColor;

      _timer += Time.deltaTime;
      if (_timer <  _waitingTime)
      {
         return;
      }

      if (_recoloringTime >= _recoloringDuration)
      {
         _recoloringTime = 0f;
         GeneratorNextColor();
         _timer = 0;
      }
   }
}
