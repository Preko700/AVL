using System;

namespace AVLTreeLibrary
{
    // Representa un nodo en un árbol AVL
    public class AVLNode
    {
        // El valor del nodo
        public int Key { get; set; }

        // La altura del nodo
        public int Height { get; set; }

        // Hijo izquierdo
        public AVLNode? Left { get; set; } // Marcado como nullable para permitir valores null

        // Hijo derecho
        public AVLNode? Right { get; set; } // Marcado como nullable para permitir valores null

        // Constructor para crear un nuevo nodo con un valor específico
        public AVLNode(int key)
        {
            Key = key;
            Height = 1; // Un nuevo nodo siempre tiene altura 1
            Left = null; // Inicializado como null
            Right = null; // Inicializado como null
        }
    }
}
