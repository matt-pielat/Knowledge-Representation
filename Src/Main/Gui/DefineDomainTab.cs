﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KR.Main.Entities;
using KR.Main.Entities.Statements;
using KR.Main.Gui.ClauseControls;

namespace KR.Main.Gui
{
    public partial class DefineDomainTab : UserControl
    {
        UserControl[] clauseControls;
        int currentClause;
        Domain _domain;
        List<Actor> availableActors = new List<Actor>();

        /// <summary>
        /// Initializes domain tab with dynamically changing domain entries.
        /// User can create his own clauses regardless of their size.
        /// </summary>
        public DefineDomainTab()
        {
            InitializeComponent();
            _domain = new Domain();
            currentClause = 0;
            clauseControls = new UserControl[] {
                new InitiallyClauseControl(),
                new CausesClauseControl(),
                new TypicallyCausesClauseControl(),
                new ReleasesClauseControl(),
                new PreservesClauseControl(),
                new AlwaysClauseControl(),
                new ImpossibleClauseControl() };

            foreach (UserControl c in clauseControls)
            {
                c.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            }
            this.AutoScroll = true;

            this.defineDomainPanel.Controls.Add(clauseControls[0], 0, 2);

            chooseClauseComboBox.SelectedIndex = 0;
        }

        public Domain getDomain()
        {
            return _domain;
        }

        public void ResetAll()
        {
            this.defineDomainPanel.Controls.Remove(clauseControls[currentClause]);
            currentClause = 0;
            clauseControls = new UserControl[] {
                new InitiallyClauseControl(),
                new CausesClauseControl(),
                new TypicallyCausesClauseControl(),
                new ReleasesClauseControl(),
                new PreservesClauseControl(),
                new AlwaysClauseControl(),
                new ImpossibleClauseControl() };

            foreach (UserControl c in clauseControls)
            {
                c.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            }
            this.AutoScroll = true;

            this.defineDomainPanel.Controls.Add(clauseControls[0], 0, 2);

            chooseClauseComboBox.SelectedIndex = 0;
        }
        public void setEntities(List<Fluent> fluents, List<Entities.Action> actions, List<Actor> actors)
        {
            availableActors = actors;
            ((InitiallyClauseControl)clauseControls[0]).setFluents(fluents);
            ((CausesClauseControl)clauseControls[1]).setActions(actions);
            ((CausesClauseControl)clauseControls[1]).setActors(actors);
            ((CausesClauseControl)clauseControls[1]).setFluents(fluents);
            ((TypicallyCausesClauseControl)clauseControls[2]).setActions(actions);
            ((TypicallyCausesClauseControl)clauseControls[2]).setActors(actors);
            ((TypicallyCausesClauseControl)clauseControls[2]).setFluents(fluents);
            ((ReleasesClauseControl)clauseControls[3]).setActions(actions);
            ((ReleasesClauseControl)clauseControls[3]).setActors(actors);
            ((ReleasesClauseControl)clauseControls[3]).setFluents(fluents);
            ((PreservesClauseControl)clauseControls[4]).setActions(actions);
            ((PreservesClauseControl)clauseControls[4]).setActors(actors);
            ((PreservesClauseControl)clauseControls[4]).setFluents(fluents);
            ((AlwaysClauseControl)clauseControls[5]).setFluents(fluents);
            ((ImpossibleClauseControl)clauseControls[6]).setActions(actions);
            ((ImpossibleClauseControl)clauseControls[6]).setActors(actors);
            ((ImpossibleClauseControl)clauseControls[6]).setFluents(fluents);
        }

        public void cleanDomain()
        {
            clausesListBox.Items.Clear();
            _domain.Clear();
        }

        public bool definedInitially()
        {
            return _domain.definedInitially();
        }

        private void chooseClauseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.defineDomainPanel.Controls.Remove(clauseControls[currentClause]);
            currentClause = chooseClauseComboBox.SelectedIndex;
            this.defineDomainPanel.Controls.Add(clauseControls[currentClause], 0, 2);
        }

        private void addClauseButton_Click(object sender, EventArgs e)
        {
            Actor epsilonActor = new Actor("ϵ");
            switch (currentClause)
            {
                case 0:
                    {
                        Initially stmt = ((InitiallyClauseControl)clauseControls[currentClause]).getClause();
                        if (stmt != null)
                        {
                            clausesListBox.Items.Add(stmt);
                            _domain.AddInitiallyClause(stmt);
                        }
                        break;
                    }
                case 1:
                    {
                        Causes stmt = ((CausesClauseControl)clauseControls[currentClause]).getClause();
                        if (stmt != null)
                        {
                            if (stmt.Actors.Contains(epsilonActor))
                                stmt = new Causes(stmt.Action, stmt.Exclusion, availableActors, stmt.Effect, stmt.Condition);
                            clausesListBox.Items.Add(stmt);
                            _domain.AddCausesClause(stmt);
                        }
                        break;
                    }
                case 2:
                    {
                        TypicallyCauses stmt = ((TypicallyCausesClauseControl)clauseControls[currentClause]).getClause();
                        if (stmt != null)
                        {
                            if (stmt.Actors.Contains(epsilonActor))
                                stmt = new TypicallyCauses(stmt.Action, stmt.Exclusion, availableActors, stmt.Effect, stmt.Condition);
                            clausesListBox.Items.Add(stmt);
                            _domain.AddTypicallyCausesClause(stmt);
                        }
                        break;
                    }
                case 3:
                    {
                        Releases stmt = ((ReleasesClauseControl)clauseControls[currentClause]).getClause();
                        if (stmt != null)
                        {
                            if (stmt.Actors.Contains(epsilonActor))
                                stmt = new Releases(stmt.Action, stmt.Exclusion, availableActors, stmt.Fluent, stmt.Condition);
                            clausesListBox.Items.Add(stmt);
                            _domain.AddReleasesClause(stmt);
                        }
                        break;
                    }
                case 4:
                    {
                        Preserves stmt = ((PreservesClauseControl)clauseControls[currentClause]).getClause();
                        if (stmt != null)
                        {
                            if (stmt.Actors.Contains(epsilonActor))
                                stmt = new Preserves(stmt.Action, stmt.Exclusion, availableActors, stmt.Fluent, stmt.Condition);
                            clausesListBox.Items.Add(stmt);
                            _domain.AddPreservesClause(stmt);
                        }
                        break;
                    }
                case 5:
                    {
                        Always stmt = ((AlwaysClauseControl)clauseControls[currentClause]).getClause();
                        if (stmt != null)
                        {
                            clausesListBox.Items.Add(stmt);
                            _domain.AddAlwaysClause(stmt);
                        }
                        break;
                    }
                case 6:
                    {
                        Impossible stmt = ((ImpossibleClauseControl)clauseControls[currentClause]).getClause();
                        if (stmt != null)
                        {
                            if (stmt.Actors.Contains(epsilonActor))
                                stmt = new Impossible(stmt.Action, stmt.Exclusion, availableActors, stmt.Condition);
                            clausesListBox.Items.Add(stmt);
                            _domain.AddImpossibleClause(stmt);
                        }
                        break;
                    }
            }
        }

        private void deleteClauseButton_Click(object sender, EventArgs e)
        {
            if (clausesListBox.SelectedIndex >= 0)
            {
                Object selectedClause = clausesListBox.SelectedItem;
                if (selectedClause is Initially)
                {
                    _domain.DeleteInitiallyClause((Initially)selectedClause);
                }
                else if (selectedClause is Causes)
                {
                    _domain.DeleteCausesClause((Causes)selectedClause);
                }
                if (selectedClause is TypicallyCauses)
                {
                    _domain.DeleteTypicallyCausesClause((TypicallyCauses)selectedClause);
                }
                else if (selectedClause is Releases)
                {
                    _domain.DeleteReleasesClause((Releases)selectedClause);
                }
                if (selectedClause is Preserves)
                {
                    _domain.DeletePreservesClause((Preserves)selectedClause);
                }
                else if (selectedClause is Always)
                {
                    _domain.DeleteAlwaysClause((Always)selectedClause);
                }
                if (selectedClause is Impossible)
                {
                    _domain.DeleteImpossibleClause((Impossible)selectedClause);
                }

                clausesListBox.Items.Remove(selectedClause);
            }
        }
    }
}
