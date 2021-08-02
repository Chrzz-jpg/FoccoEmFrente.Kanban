import React from "react"
import Activity from "../Activity";
export default function Pipe({activities, status, onDelete, onUpdate, onActivityDrop}) {

    const activitiesList = activities && activities.filter((a) => a.status === status);
   
    const onDragActivityOver = (event) => {
        event.preventDefault();
    }

    const onDropActivity = (event) => {
        const activityId = event.dataTransfer.getData("activityId");
        if (activityId && onActivityDrop) onActivityDrop(activityId)
    }
    const onDeleteActivity = (activity) => {
        if(onDelete)
            onDelete(activity)
    }

    const onUpdateAcitivity = (activity) => {
        if (onUpdate) onUpdate(activity)
    }
    
    // if ternário
    const title = 
        status === 0 
            ? "To Do" 
            : status === 1 
            ? "Doing"
            : "Done";
   
    return (
        <div className={`pipe pipe-${status}`} onDragOver={onDragActivityOver} onDrop={onDropActivity}>
            <span className="pipe-title">
                 {title} ({activitiesList.length})
            </span>
            {activitiesList.map((activity, index) => {
                 return <Activity activity={activity} key={index} onDelete={onDeleteActivity} onUpdate={onUpdateAcitivity}/>;
            })}
        </div>
    )
}