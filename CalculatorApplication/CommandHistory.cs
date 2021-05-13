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
        private int lastCommandIndex;

        public CommandHistory()
        {
            this.commands = new ICommand[HISTORY_CAPACITY];
            lastCommandIndex = -1;
        }

        /// <summary>
        /// The number of commands in the history.
        /// </summary>
        public int Count => lastCommandIndex + 1;

        /// <summary>
        /// Adds a command to the history. If the history
        /// is full, the next command that is added
        /// will move previous commands back and the first one
        /// will be lost.
        /// </summary>
        /// <param name="command">The command to be added.</param>
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
        }



        /// <summary>
        /// Gets the last command in the history and removes it.
        /// </summary>
        /// <returns>The last command in the history or null if there are no commands left.</returns>
        public ICommand RemoveLastCommand()
        {
            // no commands left in list of commands
            if (lastCommandIndex == -1) return null;

            ICommand lastCommand = commands[lastCommandIndex];
            lastCommandIndex--;
            commands[lastCommandIndex + 1] = null;
            return lastCommand;
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
            // no commands in list of commands
            if (lastCommandIndex == -1) return null;

            return commands[lastCommandIndex];
        }
    }
}
