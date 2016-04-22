﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KR.Main.Entities.Conditions;

namespace KR.Main.Entities.Statements
{
    class TypicallyCauses
    {
        public Action Action { get; private set; }
        public bool Exclusion { get; private set; }
        public List<Actor> Actors { get; private set; }
        public ICondition Effect { get; private set; }
        public ICondition Condition { get; private set; }

        /// <summary>
        /// Creates instance of typically causes sentence for given action, actors, effect and condition.
        /// </summary>
        /// <param name="action">action for sentence</param>
        /// <param name="exclusion">exclusion of actors</param>
        /// <param name="actors">actors for sentence</param>
        /// <param name="effect">effect for sentence</param>
        /// <param name="condition">condition for sentence</param>
        public TypicallyCauses(Action action, bool exclusion, List<Actor> actors, ICondition effect, ICondition condition)
        {
            Action = action;
            Exclusion = exclusion;
            Actors = actors;
            Effect = effect;
            Condition = condition;
        }
    }
}