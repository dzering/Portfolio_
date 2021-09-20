using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal sealed class GameObjectVisualBuilder : GameObjectBuilder
    {
        public GameObjectVisualBuilder(GameObject gameObject) : base(gameObject) { }

        public GameObjectVisualBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }

        public GameObjectVisualBuilder Sprite(Sprite sprite)
        {
            var component = GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return this;
        }

        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if (!result)
            {
                result = _gameObject.AddComponent<T>();
            }

            return result;
        }
    }
}