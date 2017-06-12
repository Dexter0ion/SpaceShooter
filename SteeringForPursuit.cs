using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringForPursuit : Steering {
	public GameObject target;
	private Vector3 desiredVelocity;
	private Vehicle m_vehicle;
	private float maxSpeed;
	
	// Use this for initialization
	void Start () {
        m_vehicle = GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;
	}

    public override Vector3 Force()
    {
        Vector3 toTarget = target.transform.position - transform.position;
        //计算追逐者的前向雨逃避者前向的夹角
        float relativeDirection = Vector3.Dot(transform.forward, target.transform.forward);
        //如果夹角大于零 且面对 朝逃避者当前方向移动
        if((Vector3.Dot(toTarget,transform.forward)>0)&&(relativeDirection<-0.95f))
        {
            //计算预期速度
            desiredVelocity = (target.transform.position - transform.position).normalized * maxSpeed;
            //返回操作向量
            return (desiredVelocity - m_vehicle.velocity);
        }
        //计算预测时间 正比于追逐者 逃避者的距离，反比于追逐者和逃避者的速度和
        float lookaheadTime = toTarget.magnitude / (maxSpeed + target.GetComponent<Vehicle>().velocity.magnitude);
        //计算预期速度
        desiredVelocity = (target.transform.position + target.GetComponent<Vehicle>().velocity * lookaheadTime - transform.position).normalized * maxSpeed;
        //返回操作向量
        return (desiredVelocity - m_vehicle.velocity);
    }
    // Update is called once per frame

}
