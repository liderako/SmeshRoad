using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{

    public class ColorManager : MonoBehaviour
    {
        #region Inspector Var

        [SerializeField] private List<Color> colors;
        [SerializeField] private Color _waitColorTrap;
        [SerializeField] private Color _unavailableColorTrap;
        [SerializeField] private Color _availableColorTrap;
        #endregion
        
        #region Properties

        public static ColorManager CM;

        #endregion

        #region Member var

        private Color _currentLevelColor;

        #endregion

        #region Unity Methods

        public void Awake()
        {
            if (CM == null)
            {
                CM = this;
            }
            _currentLevelColor = GetRandomColor();
        }


        #endregion

        #region Public Methods
        

        #region Gets methods

        public Color WaitColorTrap => _waitColorTrap;

        public Color UnavailableColorTrap => _unavailableColorTrap;

        public Color AvailableColorTrap => _availableColorTrap;

        public Color GetLevelColor => _currentLevelColor;

        #endregion


        #endregion

        #region Private Methods

        private Color GetRandomColor()
        {
            int number = Random.Range(0, colors.Count);
            return colors[number];
        }

        private void Clear()
        {
            _currentLevelColor = GetRandomColor();
        }

        #endregion
    }
}