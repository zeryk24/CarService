import React, {useState, useEffect} from 'react';
import {View} from 'react-native';
import RepairFasade from '../fasade/RepairFasade';
import ActivityAccordion from '../components/ActivityAccordion';
import { Provider, Portal } from 'react-native-paper';
import AddActivityFAB from './../components/AddActivityFAB';
import AddActivityDialog from '../components/AddActivityDialog';

const Activities = ({route}) => {
  const repair = route.params;
  const [dialogVisible, setDialogVisible] = useState(false);
  const [activities, setActivities] = useState([]);
  fasade = new RepairFasade();

  useEffect(() => {
    fasade.GetRepairById(repair.id).then(data => {
      setActivities(data.activities);
    });
  }, []);
  return (
    <Portal.Host>
      <View style={{flex: 1, backgroundColor: '#4c4c4c'}}>
        {activities.map(item => (
          <ActivityAccordion key={item.id} {...item} repairId={repair.id}/>
        ))}
      </View>
      <AddActivityFAB {...{dialogVisible, setDialogVisible}}/>
      <AddActivityDialog {...{setActivities, dialogVisible, setDialogVisible}} repairId={repair.id}/>
    </Portal.Host>
  );
};

export default Activities;
