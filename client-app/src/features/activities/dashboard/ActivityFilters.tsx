import React from 'react';
import Calendar from 'react-calendar';
import {Header, Menu } from 'semantic-ui-react';

export default function ActivityFilters() {
    
    return (
        <>
      <Menu vertical verticalsize={'large'} style={{width : '100%', marginTop:29}}>
          <Header icon={'filter'} attached color={'teal'} content={'Filters'} />
          <Menu.Item content={'All activities'}/>
          <Menu.Item content={"I'm going"}/>
          <Menu.Item content={"I'm hosting"}/>
      </Menu>
            <Header />
            <Calendar />
            
        </>
    )
}