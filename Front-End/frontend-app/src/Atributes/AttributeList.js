import React,{useEffect,Fragment} from "react";
import { observer } from "mobx-react-lite";
import { useStore } from "../Store/Store";
import {Button,Modal,Header,Icon} from 'semantic-ui-react'
import { AttributesForm } from "./AttributeForm";



export default observer(function AttributeList(){
    const {AttributeStore}=useStore();
    const{selectedAttribute,openForm,attributes,attributevalues,editmode,selectAttribute,deleteAttribute}=AttributeStore;
    const [open, setOpen] = React.useState(false)

    useEffect(()=>{
        AttributeStore.loadAttributes();
        AttributeStore.loadAttributesValues()
    },[AttributeStore]);

    

   function del(id)
   {
    selectAttribute(id);
    setOpen(true);
    
   }
    
    return(
      <Fragment>
      <Button floated='right' content="add" color='blue'onClick={()=> openForm()}/>
        <div className="container">
    <table className="table table-hover">
        <thead className="table-dark">
            <tr>
            <th scope="col">Id</th>
            <th scope="col">AttributeName</th>
            <th scope="col">attributevalues</th>
            <th scope="col">edit</th>
            <th scope="col">delete</th>
            </tr>
        </thead>
        <tbody>
            {attributes.map((attr)=>(
                 <tr key={attr.attributeId} className="table-secondary">
                 <th scope="row">{attr.attributeId}</th>
                 <td>{attr.name}</td>
                 
                 <td>{attributevalues.filter(a=> a.attributeId==attr.attributeId).map((val)=><p>{val.value}</p> )}</td>
                 <td><Button color='blue' content='edit' onClick={()=> openForm(attr.attributeId)} /></td>
                 <td><Button  color='red' content='delete'onClick={()=> del(attr.attributeId)}/></td>
                 </tr>
            ))}
            
        </tbody>
        <Modal
      closeIcon
      open={open}
      //trigger={<Button>Show Modal</Button>}
      onClose={() => setOpen(false)}
      onOpen={() => setOpen(true)}
    >
      <Header icon='archive' content='Archive Old Messages' />
      <Modal.Content>
        <p>
         Product
        </p>
      </Modal.Content>
      <Modal.Actions>
        <Button color='red' onClick={() => setOpen(false)}>
          <Icon name='remove' /> No
        </Button>
        <Button color='green'onClick={()=>deleteAttribute(selectedAttribute.attributeId)} >
          <Icon name='checkmark' /> Yes 
        </Button>
      </Modal.Actions>
    </Modal>
        </table> 
        <Modal
      onClose={() => openForm(false)}
      onOpen={() => openForm(true)}
      open={editmode}
     // trigger={<Button>Show Modal</Button>}
    >
      
     <Modal.Description>
        
        
         <AttributesForm/>
         
      </Modal.Description>
      
        
      
    </Modal>
        </div>
        </Fragment>
    )
}
)