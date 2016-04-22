﻿using System;
using KR.Main.Entities.Conditions;

namespace KR.Main.Entities
{
    /// <summary>
    /// Class representing fluent object.
    /// </summary>
    public class Fluent : ICondition, IEquatable<Fluent>
    {
        private string _name;

        /// <summary>
        /// Creates instance of an fluent object.
        /// </summary>
        /// <param name="name">fluent name</param>
        public Fluent(string name)
        {
            _name = name;
        }
        public bool Check(State state)
        {
            return state[this];
        }

        public bool Equals(Fluent other)
        {
            return other._name.Equals(_name);
        }

        public override string ToString()
        {
            return this._name;
        }

        
    }
}
