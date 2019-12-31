using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrototypeProgram
{

	public interface IElement
	{
		IEnumerator Execute(GameObject gameObject);
	}

    /*public class MoveCommand : Element
    {
        public enum Direction
		{
			FWD, BWD
		}

		private Direction _direction;
		private float _distance;

		public MoveCommand(Direction direction, float distance)
		{
			_direction = direction;
			_distance = distance;
		}

		public IEnumerator Execute(GameObject gameObject)
		{
			float d = 0f;

			switch(_direction)
			{
				case Direction.FWD: {
					d = _distance;
				} break;
				case Direction.BWD: {
					d = -_distance;
				} break;
			}

			Vector3 v = Vector3.up * d;
			gameObject.transform.Translate(v);

			#if DEBUG
			Debug.Log ("Move " + _direction + " " + _distance);
			#endif

			return null;
		}
    }*/

    /*public class RotateCommand : Element
    {
        private float _angle;

		public RotateCommand(float angle)
		{
			_angle = angle;
		}

		public IEnumerator Execute(GameObject gameObject)
		{
			gameObject.transform.Rotate(new Vector3(0, 0, _angle));

			#if DEBUG
			Debug.Log ("Rotate " + _angle);
			#endif

			return null;
		}
    }*/

    public class PlayerElement : IElement
    {
        private readonly int _num; //change to just private if having problems later

        public PlayerElement(int num)
        {
            _num = num;
        }

        public IEnumerator Execute(GameObject gameObject) //What it should do when this command gets executed
        {
            //TODO: CODE TO CREATE PLAYER(S)
            for (int i = 0; i < _num; i++)
            {
                //create player
            }

            Debug.Log("Player x" + _num);

            return null;
        }
    }

    public class MapElement : IElement
    {
        public enum Size
        {
            SMALL, MED, LARGE
        }

        private Size _size;

        public MapElement(Size size)
        {
            _size = size;
        }

        public IEnumerator Execute(GameObject gameObject) //What it should do when this command gets executed
        {
            //TODO: CODE TO CREATE MAP

            Debug.Log("Map: " + _size.ToString());

            return null;
        }
    }

    public class EnemyElement : IElement
    {
        public enum Skill
        {
            BASIC, BALANCED, SKILLED
        }

        public enum Type
        {
            TYPEA, TYPEB
        }

        private readonly Skill _skill;
        private readonly int _num;
        private readonly Type _type;

        public EnemyElement(Type type, int num, Skill skill)
        {
            _skill = skill;
            _num = num;
            _type = type;
        }

        public IEnumerator Execute(GameObject gameObject) //What it should do when this command gets executed - will just be creation because the grammar isn't doing anything with gameplay... for now... 
        {
            //TODO: CODE TO CREATE AND PLACE ENEMIES

            Debug.Log("Enemy: " + _type.ToString() + ", " + _skill.ToString() + " x" + _num);

            return null;
        }
    }

    public static float EXECUTION_DELAY = 0.5f;

	private List<IElement> _elements;
	private int _pc;

	public PrototypeProgram(List<IElement> elements)
	{
        _elements = elements;
		_pc = 0;
	}


	public IEnumerator Run(GameObject gameObject)
	{
		while(_pc < _elements.Count)
		{
			yield return new WaitForSeconds(EXECUTION_DELAY);

            IElement nextElement = _elements[_pc++];
			yield return nextElement.Execute(gameObject);
		}
	}


	public void Reset()
	{
		_pc = 0;
	}
}
