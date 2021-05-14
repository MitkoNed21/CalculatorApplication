using CalculatorApplication.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication
{
    public class CommandHistory
    {
        private const int HISTORY_CAPACITY = 20;
        private ICommand[] commands;
        private ICommand[] undoneCommands;
        private int lastCommandIndex;
        private int lastUndoneCommandIndex;

        public CommandHistory()
        {
            this.commands = new ICommand[HISTORY_CAPACITY];
            this.undoneCommands = new ICommand[HISTORY_CAPACITY];
            lastCommandIndex = -1;
            lastUndoneCommandIndex = -1;
        }

        /// <summary>
        /// The number of commands in the history.
        /// </summary>
        public int Count => lastCommandIndex + lastUndoneCommandIndex + 2;

        /// <summary>
        /// Adds a command to the history and executes it. If the history
        /// is full, the next command that is added will move previous commands back
        /// and the first one will be lost.
        /// </summary>
        /// <param name="command">The command to be added and executed.</param>
        public void AddCommand(ICommand command)
        {
            if (lastCommandIndex == HISTORY_CAPACITY - 1)
            {
                for (int i = 1; i < HISTORY_CAPACITY; i++)
                {
                    commands[i - 1] = commands[i];
                }
            }
            else
            {
                lastCommandIndex++;
            }

            commands[lastCommandIndex] = command;
            command.Execute();

            // If last command index is -1, there are no commands
            if (lastUndoneCommandIndex != -1)
            {
                ClearUndoneCommands();
            }
        }

        /// <summary>
        /// Removes all commands from the history.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < HISTORY_CAPACITY; i++)
            {
                commands[i] = null;
            }

            lastCommandIndex = -1;

            ClearUndoneCommands();
        }

        void ClearUndoneCommands()
        {
            for (int i = 0; i < HISTORY_CAPACITY; i++)
            {
                undoneCommands[i] = null;
            }

            lastUndoneCommandIndex = -1;
        }

        /// <summary>
        /// Gets the last command in the history and removes it.
        /// </summary>
        /// <returns>The last command in the history or null if there are no commands left.</returns>
        public ICommand RemoveLastCommand()
        {
            // No commands left in list of commands
            if (lastCommandIndex == -1) return null;

            ICommand lastCommand = commands[lastCommandIndex];
            lastCommandIndex--;
            commands[lastCommandIndex + 1] = null;
            lastCommand.Unexecute();

            // Move command to undone commands list
            lastUndoneCommandIndex++;
            undoneCommands[lastUndoneCommandIndex] = lastCommand;

            return lastCommand;
        }

        /// <summary>
        /// Removes a number of commands, so that the last command in the history
        /// will be the one at the specified index.
        /// </summary>
        /// <param name="index">The index of the command to set the history at. Can't be 0 or less.</param>
        /// <returns>The command at the specified index.</returns>
        public ICommand MoveToCommandAt(int index)
        {
            if (index < 0 || index >= HISTORY_CAPACITY)
            {
                throw new ArgumentOutOfRangeException(nameof(index),
                    index,
                    $"Index was outside of history capacity (0 - {HISTORY_CAPACITY})!");
            }

            if (index <= lastCommandIndex)
            {
                while (index != lastCommandIndex)
                {
                    RemoveLastCommand();
                }
            }
            else
            {
                while (index != lastCommandIndex)
                {
                    ReaddLastRemovedCommand();
                }
            }

            return PeekLastCommand();
        }

        /// <summary>
        /// Adds back the last command that was removed from the history
        /// if no other commands have been added since the removal.
        /// </summary>
        public void ReaddLastRemovedCommand()
        {
            // No commands left in list of undone commands
            if (lastUndoneCommandIndex == -1) return;

            ICommand lastUndoneCommand = undoneCommands[lastUndoneCommandIndex];
            lastUndoneCommandIndex--;
            undoneCommands[lastUndoneCommandIndex + 1] = null;
            lastUndoneCommand.Execute();

            // Move command to commands list
            lastCommandIndex++;
            commands[lastCommandIndex] = lastUndoneCommand;
        }

        /// <summary>
        /// Returns an array copy of the commands in the history.
        /// </summary>
        /// <returns></returns>
        public ICommand[] ToArray()
        {
            ICommand[] array = commands.Where(c => !(c is null)).ToArray();
            return array;
        }

        /// <summary>
        /// Gets the last command in the history without removing it.
        /// </summary>
        /// <returns>The last command in the history or null if there are no commands left.</returns>
        public ICommand PeekLastCommand()
        {
            // If last command index is -1, there are no commands
            if (lastCommandIndex == -1) return null;

            return commands[lastCommandIndex];
        }
    }
}
