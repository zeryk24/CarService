import React, {useState, createContext, useEffect} from 'react';
import {View} from 'react-native';
import {
  List,
  Colors,
  FAB,
  Text,
  IconButton,
  TextInput,
} from 'react-native-paper';
import ActivityStateIcon from './ActivityStateIcon';
import ChooseStateDialog from './ChooseStateDialog';
import ActivityFasade from '../fasade/ActivityFasade';
import MaterialFasade from '../fasade/MaterialFasade';

export const DialogContext = createContext(null);

const ActivityAccordion = ({name, description, state, id, repairId}) => {
  const addMaterialName = materials => {
    return materials.map(material => ({
      ...material,
      name: materialsMapping.find(item => item.id === material.id).name,
    }));
  };
  const [expanded, setExpanded] = useState(false);
  const [dialogVisible, setDialogVisible] = useState(false);
  const [activityState, setActivityState] = useState(state);
  const [materials, setMaterials] = useState([]);
  const [materialsMapping, setMaterialsMapping] = useState([]);
  const [inputMaterial, setInputMaterial] = useState({name: '', amount: 0});
  const [showInputMaterial, setShowInputMaterial] = useState(true);

  const activityFasade = new ActivityFasade();
  const materialFasade = new MaterialFasade();

  useEffect(() => {
    materialFasade.GetMaterials().then(data => {
      setMaterialsMapping(data);
    });
  }, []);

  const handlePress = () => {
    setExpanded(!expanded);
    activityFasade.GetActivityById(id).then(activities => {
      setMaterials(addMaterialName(activities.consumes));
    });
  };
  return (
    <View>
      <List.Accordion
        title={name}
        style={{backgroundColor: '#333333'}}
        titleStyle={{color: '#E5E5E5'}}
        descriptionStyle={{color: '#CCCCCC'}}
        description={description}
        expanded={expanded}
        onPress={handlePress}>
        {materials.map((material, index) => (
          <List.Item
            style={{backgroundColor: '#4c4c4c'}}
            titleStyle={{color: '#E5E5E5'}}
            key={index}
            title={material.name}
            right={() => (
              <Text style={{color: '#E5E5E5', padding: 7}}>
                {material.amount + 'x'}
              </Text>
            )}
          />
        ))}
        {showInputMaterial ? (
          <IconButton
            icon="plus-circle"
            color={Colors.orange500}
            size={30}
            onPress={() => {
              setInputMaterial({});
              setShowInputMaterial(false);
            }}
          />
        ) : (
          <View style={{flexDirection: 'row'}}>
            <TextInput
              selectionColor="#FF8C00"
              theme={{colors: {primary: '#000'}}}
              style={{flex: 2, height: 60, margin:5, justifyContent: 'center'}}
              label="Jméno položky"
              value={inputMaterial.name}
              onChangeText={newValue =>
                setInputMaterial({...inputMaterial, name: newValue})
              }
            />
            <TextInput
              selectionColor="#FF8C00"
              style={{flex: 1, height: 60, margin:5, justifyContent: 'center'}}
              theme={{colors: {primary: '#000'}}}
              label="Množství"
              value={inputMaterial.amount}
              onChangeText={newValue =>
                setInputMaterial({...inputMaterial, amount: newValue})
              }
              keyboardType={'numeric'}
            />
            <IconButton
              icon="plus-circle"
              color={Colors.orange500}
              size={30}
              onPress={() => {
                setMaterials(prev => [
                  ...prev,
                  {name: inputMaterial.name, amount: inputMaterial.amount},
                ]);
                setShowInputMaterial(true);
              }}
            />
          </View>
        )}
      </List.Accordion>

      <DialogContext.Provider value={{dialogVisible, setDialogVisible}}>
        <View style={{position: 'absolute', left: 280, top: 12}}>
          <ActivityStateIcon state={activityState} />
        </View>
        <ChooseStateDialog
          setActivityState={setActivityState}
          activityData={{name, description, state, id, repairId}}
        />
      </DialogContext.Provider>
    </View>
  );
};

export default ActivityAccordion;
