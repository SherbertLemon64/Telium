using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    public Module[] Modules;

    public GameObject ModulePrefab;
    public GameObject LinePrefab;

    public readonly Vector3[] CardinalDirections = new[]
    {
        Vector3.up,
        Vector3.down,
        Vector3.left,
        Vector3.right
    };
    
    void Start()
    {
        Instance = this;
        
        GenerateMap(15,2);
    }

    public void GenerateMap(int _amount, int _connections)
    {
        List<Module> modules = new List<Module>();
        Queue<Module> itemsToAdd = new Queue<Module>();
        Module first = MakeModule(Vector3.zero);
        
        itemsToAdd.Enqueue(first);
        modules.Add(first);

        while (modules.Count < _amount && itemsToAdd.Count > 0)
        {
            Module module = itemsToAdd.Dequeue();

            for (int i = 0; i < _connections; i++)
            {
                Vector3 location = module.transform.position + CardinalDirections[Random.Range(0, 4)] * 2.5f;
                Module locatedModule = ModuleAtLocation(location, modules);

                if (locatedModule != null && !module.Neighbours.Contains(locatedModule))
                {
                    module.Neighbours.Add(locatedModule);
                    locatedModule.Neighbours.Add(module);
                    DrawLine(module,locatedModule);
                }
                else if (!module.Neighbours.Contains(locatedModule))
                {
                    Module newModule = MakeModule(location);
                    module.Neighbours.Add(newModule);
                    newModule.Neighbours.Add(module);
                    itemsToAdd.Enqueue(newModule);
                    modules.Add(module);
                    DrawLine(module,newModule);
                }
            }
        }

        Player.Instance.Move(first);
    }

    public Module ModuleAtLocation(Vector3 _location, List<Module> _modules)
    {
        foreach (Module m in _modules)
        {
            if (m.transform.position == _location)
            {
                return m;
            }
        }

        return null;
    }
    public Module MakeModule(Vector3 _location)
    {
        GameObject module = Instantiate(ModulePrefab,_location,quaternion.identity);
        module.transform.SetParent(transform);
        return module.GetComponent<Module>();
    }

    public void DrawLine(Module _moduleOne, Module _moduleTwo)
    {
        GameObject line = Instantiate(LinePrefab);
        LineRenderer renderer = line.GetComponent<LineRenderer>();
        
        renderer.SetPosition(0, _moduleOne.transform.position);
        renderer.SetPosition(1, _moduleTwo.transform.position);
    }
}
