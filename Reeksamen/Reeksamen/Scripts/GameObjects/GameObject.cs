﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reeksamen.Scripts.Components;
using Reeksamen.Scripts.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//GameObject So That We Can Add Components And TransForms To Our GameObjects
namespace Reeksamen.Scripts
{
    public class GameObject
    {
        private Dictionary<string, Component> components = new Dictionary<string, Component>();
        public Transform Transform { get; private set; }
        public Dictionary<string, Component> Components { get => components; set => components = value; }

        public string Tag { get; set; }
        public Scene MyScene { get; set; }

        public GameObject()
        {
            Transform = new Transform();
        }

        public void Awake()
        {
            foreach (Component component in Components.Values)
            {
                component.Awake();
            }
        }
        public void Start()
        {
            foreach (Component component in Components.Values)
            {
                component.Start();
            }
        }
        public void Update(GameTime gameTime)
        {
            foreach (Component component in Components.Values)
            {
                if (component.IsEnable)
                {
                    component.Update(gameTime);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component component in Components.Values)
            {
                if (component.IsEnable)
                {
                    component.Draw(spriteBatch);
                }
            }
        }
        public void Destroy()
        {
            foreach (Component component in Components.Values)
            {
                component.Destroy();
            }
        }
        public Component AddComponent(Component component)
        {
            AddComponentToDictionary(component);

            return component;
        }
        private void AddComponentToDictionary(Component component)
        {
            if (!components.ContainsKey(component.ToString()))
            {
                components.Add(component.ToString(), component);
                component.GameObject = this;
            }
            else
            {
                Console.WriteLine("Error tried to add same component twice");
            }
        }
        public T GetComponent<T>() where T : Component
        {
            foreach (Component item in components.Values)
            {
                if (item is T)
                {
                    return item as T;
                }
            }
            return null;
        }
    }
}
