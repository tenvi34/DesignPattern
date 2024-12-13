using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBikeState
{
    // 상태 클래스가 BikeController의 public 속성에 접근 가능하게 한다.
    void Handle(BikeController controller);
}
