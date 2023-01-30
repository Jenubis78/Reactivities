import { useEffect } from 'react';
//import logo from './logo.svg';
import './styles.css';
//import { ducks } from './demo';
//import DuckItem from './DuckItem';
import { Container } from 'semantic-ui-react';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import LoadingComponent from './LoadingComponent';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';

function App() {

const {activityStore} = useStore();


  useEffect(() => {
   activityStore.loadActivities();

  }, [activityStore])


  if (activityStore.loadingInitial) return <LoadingComponent content='Loading app'/>
  return (
    <>
      <NavBar />
      <Container style={{ marginTop: '7em' }}>
        <ActivityDashboard />
      </Container>




    </>
  );
}

export default observer(App) ;
