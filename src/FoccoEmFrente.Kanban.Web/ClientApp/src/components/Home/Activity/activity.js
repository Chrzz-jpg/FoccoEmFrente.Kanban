import React, { useState } from "react";

export default function Activity({ activity, onDelete, onUpdate }) {
  const [editing, setEditing] = useState(false);

  const [title, setTitle] = useState(activity.title);

  const onDeleteActivity = () => {
    if (onDelete) onDelete(activity);
  };

  const onEnterEditinMode = () => {
    setEditing(true);
  };

  const setActivityTitle = (value) => {
    setTitle(value);
  };

  const onBlurTitle = () => {
    setEditing(false);
    activity.title = title;
    if (onUpdate) onUpdate(activity);
  };

  const onDragActivity = (event) => {
      event.dataTransfer.setData("activityId",activity.id);
  }

  return (
    <div draggable={!editing} className={"activity"} onDragStart={onDragActivity}>
      <button className="btn-delete-activity" onClick={onDeleteActivity}>
        X
      </button>
      {editing ? (
        <input
          value={title}
          onBlur={onBlurTitle}
          autoFocus
          onChange={(event) => setActivityTitle(event.target.value)}
        ></input>
      ) : (
        <span onDoubleClick={onEnterEditinMode}>{activity.title}</span>
      )}
    </div>
  );
}
