﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KR.Main.Entities.Conditions;

namespace KR.Main.Entities.Statements
{
    public class Observable
    {
        public ICondition Effect { get; private set; }
        public List<Tuple<Action, bool, List<Actor>>> Sequence { get; private set; }

        /// <summary>
        /// Creates instance of observable after sentence for given effect and sequence of actions.
        /// </summary>
        /// <param name="effect">effect for sentence</param>
        /// <param name="sequence">sequence of action with actors</param>
        public Observable(ICondition effect, List<Tuple<Action, bool, List<Actor>>> sequence)
        {
            Effect = effect;
            Sequence = sequence;
        }
    }
}
