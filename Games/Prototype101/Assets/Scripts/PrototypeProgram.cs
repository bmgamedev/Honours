using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrototypeProgram
{

	public interface IElement
	{
        //IEnumerator Execute(GameObject gameObject);
        IEnumerator Execute();
    }

    public class PlayerElement : IElement
    {
        private readonly int _num; //change to just private if having problems later

        public PlayerElement(int num)
        {
            _num = num;
        }

        //public IEnumerator Execute(GameObject gameObject)
        public IEnumerator Execute() //What it should do when this command gets executed
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

        //public IEnumerator Execute(GameObject gameObject)
        public IEnumerator Execute() //What it should do when this command gets executed
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

        //public IEnumerator Execute(GameObject gameObject)
        public IEnumerator Execute() //What it should do when this command gets executed - will just be creation because the grammar isn't doing anything with gameplay... for now... 
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

    //public IEnumerator Run(GameObject gameObject)
    /*public IEnumerator Run()
	{
		while(_pc < _elements.Count)
		{
			yield return new WaitForSeconds(EXECUTION_DELAY);

            IElement nextElement = _elements[_pc++];
            //yield return nextElement.Execute(gameObject);
            yield return nextElement.Execute();
		}
    }*/

    public IEnumerator Run()
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Game"); //load the game scene
        asyncOperation.allowSceneActivation = false; //don't immediately activate scene (wait until objects have been created)

        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {

                while (_pc < _elements.Count)
                {
                    yield return new WaitForSeconds(EXECUTION_DELAY);

                    IElement nextElement = _elements[_pc++];

                    //Debug.Log("next element: " + nextElement.ToString());
                    nextElement.Execute();
                }

                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }


    public void Reset()
	{
		_pc = 0;
	}
}
