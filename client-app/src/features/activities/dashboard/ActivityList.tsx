import { observer } from 'mobx-react-lite';
import {Fragment, SyntheticEvent, useState} from 'react';
import { Link } from 'react-router-dom';
import { Item, Segment, Button, Label, Header } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';
import ActivityListItem from './ActivityListItem';


export default observer (function ActivityList() {

const {activityStore} = useStore();

const {groupedActivities} = activityStore;


    return (
        <>
            {groupedActivities.map(([group, activities]) => (
            <Fragment key={group}>
                <Header sub color='teal'>
                    {group}
                </Header>
                {activities.map(activity => (
<ActivityListItem  key= {activity.id} activity={activity} />
                   
                ))}
         
            </Fragment>
    ))}
            </>
    )
})