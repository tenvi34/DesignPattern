using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum RaceEventType
{
    COUNTDOWN,
    START,
    RESTART,
    PAUSE,
    STOP,
    FINISH,
    QUIT
}

public class RaceEventBus
{
    // 이벤트 이름과 해당 이벤트의 타입을 관리하는 딕셔너리
    private static readonly IDictionary<RaceEventType, UnityEvent> Events = new Dictionary<RaceEventType, UnityEvent>();

    // 이벤트에 리스너를 추가하는 메서드
    public static void Subscribe(RaceEventType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        // 이벤트가 이미 존재하는지 확인
        if (Events.TryGetValue(eventType, out thisEvent))
        {
            // 존재하면 리스너 추가
            thisEvent.AddListener(listener);
        }
        else
        {
            // 존재하지 않으면 새 이벤트 생성 후 리스너 추가
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    // 이벤트에서 리스너를 제거하는 메서드
    public static void UnSubscribe(RaceEventType type, UnityAction listener)
    {
        UnityEvent thisEvent;

        // 이벤트가 존재하는지 확인
        if (Events.TryGetValue(type, out thisEvent))
        {
            // 존재하면 리스너 제거
            thisEvent.RemoveListener(listener);
        }
    }

    // 이벤트를 트리거하는 메서드
    public static void Publish(RaceEventType type)
    {
        UnityEvent thisEvent;

        // 이벤트가 존재하는지 확인
        if (Events.TryGetValue(type, out thisEvent))
        {
            // 존재하면 이벤트 트리거
            thisEvent.Invoke();
        }
    }
}