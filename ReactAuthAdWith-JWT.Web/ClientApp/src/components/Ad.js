import React from 'react';
import getAxios from '../AuthAxios';

const Ad = ({ad, deleteMode,refreshAds}) => {
    const{user, date, phoneNumber,description,id}=ad;

    const  onDeleteClick =async (id) => {
        await getAxios().post('/api/ads/deletead',{id});
        
        refreshAds();
    }

    return <div className="mt-12 jumbotron">
    {user&&<h5>Listed by </h5>}
    <h5>Listed on {date}</h5>
    <h5>Phone Number: {phoneNumber}</h5>
    <h3>Details:</h3>
    <p>{description}</p>
 
    {!!deleteMode&&<button className="btn btn-danger" onClick={onDeleteClick(id)}>Delete</button>}
</div>
}

export default Ad;